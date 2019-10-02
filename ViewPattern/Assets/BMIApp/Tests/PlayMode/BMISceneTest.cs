using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using Zenject;
using BMIApp.CleanArchitecture;
using BMIApp.BMI;

namespace BMIApp.Tests.PlayMode {
    public class BMISceneTest : SceneTestFixture {
        const string sceneName = "BMI";

        BMITestPresenter bmiPresenter = new BMITestPresenter();
        HistoryListTestPresenter historyPresenter = new HistoryListTestPresenter();
        AccountTestPresenter accountPresenter = new AccountTestPresenter();
        UserAccountTestRepository accountRepository = new UserAccountTestRepository();
        BMIHistoryTestRepository historyRepository = new BMIHistoryTestRepository();

        SharedScriptableObject sharedData = default;
        TemporaryHistoryDataStore historyData = default;

        BMIView bmiView = default;
        HistoryView historyView = default;
        HistoryElmView historyElmView = default;
        AccountView accountView = default;

        void CommonInstallBindings() {
            StaticContext.Container.Bind<ITest>().To<Test>().AsTransient();
            StaticContext.Container.Bind<IBMIPresenter>().FromInstance(bmiPresenter).AsTransient();
            StaticContext.Container.Bind<IHistoryListPresenter>().FromInstance(historyPresenter).AsTransient();
            StaticContext.Container.Bind<IAccountPresenter>().FromInstance(accountPresenter).AsTransient();
            StaticContext.Container.Bind<IUserAccountRepository>().FromInstance(accountRepository).AsTransient();
            StaticContext.Container.Bind<IBMIHistoryRepository>().FromInstance(historyRepository).AsTransient();
        }

        void FindGameObjects() {
            // find
            var canvas = GameObject.Find("Canvas").transform;
            bmiView = canvas.Find("BMIView").GetComponent<BMIView>();
            historyView = canvas.Find("HistoryView").GetComponent<HistoryView>();
            accountView = canvas.Find("AccountView").GetComponent<AccountView>();
            // prefab
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/BMIApp/Prefabs/HistoryElm.prefab");
            var historyElm = prefab.GetComponent<HistoryElmView>();
            // data
            sharedData = ScriptableObject.CreateInstance<SharedScriptableObject>();
            historyData = new TemporaryHistoryDataStore();
            // set
            bmiPresenter.InnerPresenter = new BMIPresenter(bmiView);
            historyPresenter.InnerPresenter = new HistoryListPresenter(historyView, historyElm);
            accountPresenter.InnerPresenter = new AccountPresenter(accountView);
            accountRepository.InnerRepository = new UserAccountRepository(sharedData);
            historyRepository.InnerRepository = new BMIHistoryRepository(historyData);
        }

        void BeginMain() {
            GameObject.Find("SceneContext").GetComponent<IMainInstaller>().SceneMainObject.SetActive(true);
        }

        [UnityTest]
        public IEnumerator BMI計算_保存_削除までの一連の操作() {

            CommonInstallBindings();
            yield return LoadScene(sceneName);
            FindGameObjects();
            BeginMain();

            // 最初は未入力
            Assert.IsEmpty(bmiView.NameInput.text);
            Assert.IsEmpty(bmiView.HeightInput.text);
            Assert.IsEmpty(bmiView.WeightInput.text);
            Assert.IsEmpty(bmiView.AgeInput.text);
            Assert.IsFalse(bmiView.GenderMaleToggle.isOn);
            Assert.IsFalse(bmiView.GenderFemaleToggle.isOn);
            Assert.That(bmiView.BMIText.text, Is.EqualTo("99(やせすぎ)"));
            Assert.IsFalse(bmiView.SaveButton.interactable);
            Assert.That(historyView.Content.childCount, Is.Zero);

            // 名前/身長/体重を入力すると[保存]が押せるようになる
            bmiView.NameInput.onEndEdit.Invoke("test_name");
            Assert.IsFalse(bmiView.SaveButton.interactable);
            bmiView.HeightInput.onEndEdit.Invoke("123");
            Assert.IsFalse(bmiView.SaveButton.interactable);
            bmiView.WeightInput.onEndEdit.Invoke("56");
            Assert.IsTrue(bmiView.SaveButton.interactable);
            
            // 計算されたBMIと評価が表示される
            Assert.That(bmiView.BMIText.text, Is.EqualTo("37.0(肥満)"));

            // [保存]を押すとリストに追加される
            bmiView.SaveButton.onClick.Invoke();
            yield return null;
            Assert.That(historyView.Content.childCount, Is.EqualTo(1));

            // 内容が 日時-名前-BMI
            var elm = historyView.Content.GetChild(0)?.GetComponent<HistoryElmView>();
            Assert.IsFalse(elm == null);
            Assert.That(elm.DateText.text, Is.EqualTo(System.DateTime.Now.ToString("M/d")));
            Assert.That(elm.NameText.text, Is.EqualTo("test_name"));
            Assert.That(elm.BMIText.text, Is.EqualTo("37.0"));

            // 後から追加された方が上にくる
            bmiView.HeightInput.onEndEdit.Invoke("100");
            bmiView.WeightInput.onEndEdit.Invoke("1");
            bmiView.SaveButton.onClick.Invoke();
            yield return null;
            elm = historyView.Content.GetChild(0)?.GetComponent<HistoryElmView>();
            Assert.IsFalse(elm == null);
            Assert.That(elm.BMIText.text, Is.EqualTo("1.0"));

            // リポジトリにも追加されている
            Assert.That(historyData.Datas.Count, Is.EqualTo(2));

            // [クリア]でデータが消える
            historyView.ClearButton.onClick.Invoke();
            yield return null;
            Assert.That(historyView.Content.childCount, Is.Zero);
            Assert.That(historyData.Datas.Count, Is.Zero);

            yield return null;
        }
    }
}
