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
        public IEnumerator BMISceneTestWithEnumeratorPasses() {

            CommonInstallBindings();
            yield return LoadScene(sceneName);
            FindGameObjects();
            BeginMain();

            yield return null;
        }
    }
}
