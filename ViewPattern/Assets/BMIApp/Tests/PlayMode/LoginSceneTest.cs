using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Zenject;
using BMIApp.CleanArchitecture;
using BMIApp.Login;

namespace BMIApp.Tests.PlayMode {
    public class LoginSceneTest : SceneTestFixture {
        const string sceneName = "Login";

        AlertTestPresenter alertPresenter = new AlertTestPresenter();
        LoginTestPresenter loginPresenter = new LoginTestPresenter();
        UserAccountTestRepository accountRepository = new UserAccountTestRepository();
        AlertView alertView;
        LoginView loginView;
        SharedScriptableObject sharedData;

        void CommonInstallBindings() {
            StaticContext.Container.Bind<ITest>().To<Test>().AsTransient();
            StaticContext.Container.Bind<IAlertPresenter>().FromInstance(alertPresenter).AsTransient();
            StaticContext.Container.Bind<ILoginPresenter>().FromInstance(loginPresenter).AsTransient();
            StaticContext.Container.Bind<IUserAccountRepository>().FromInstance(accountRepository).AsTransient();
            StaticContext.Container.Bind<IAuthController>().To<DummyAuthController>().AsTransient();
        }

        void FindGameObjects() {
            // find
            var canvas = GameObject.Find("Canvas").transform;
            alertView = canvas.Find("AlertView").GetComponent<AlertView>();
            loginView = canvas.Find("LoginView").GetComponent<LoginView>();
            sharedData = ScriptableObject.CreateInstance<SharedScriptableObject>();
            // set
            alertPresenter.View = alertView;
            loginPresenter.View = loginView;
            accountRepository.Data = sharedData;
        }

        void BeginMain() {
            GameObject.Find("SceneContext").GetComponent<IMainInstaller>().SceneMainObject.SetActive(true);
        }

        [UnityTest]
        public IEnumerator シーンが正常に起動するか() {
            yield return LoadScene(sceneName);

            FindGameObjects();
            Assert.IsNotNull(alertView);
            Assert.IsInstanceOf<IAlertView>(alertView);
            Assert.IsNotNull(loginView);
            Assert.IsInstanceOf<ILoginView>(loginView);
            Assert.IsNotNull(sharedData);
            Assert.IsInstanceOf<ISharedData>(sharedData);
        }

        [UnityTest]
        public IEnumerator ログイン失敗でアラートが表示されるか() {
            CommonInstallBindings();
            yield return LoadScene(sceneName);
            FindGameObjects();
            BeginMain();

            // ログイン失敗でアラートが表示される
            loginView.IdInputField.onEndEdit.Invoke("hoge");
            loginView.PasswordInputField.onEndEdit.Invoke("fuga");
            loginView.LoginButton.onClick.Invoke();
            yield return null;
            Assert.IsTrue(alertView.gameObject.activeSelf);
            // アラート閉じる
            alertView.CloseButton.onClick.Invoke();
            yield return null;
            Assert.IsFalse(alertView.gameObject.activeSelf);
        }

        [UnityTest]
        public IEnumerator ログイン成功でトークンが取得されるか() {
            CommonInstallBindings();
            yield return LoadScene(sceneName);
            FindGameObjects();
            BeginMain();

            // ログイン成功でIDとトークンが保存される
            loginView.IdInputField.onEndEdit.Invoke("testuser");
            loginView.PasswordInputField.onEndEdit.Invoke("password123");
            loginView.LoginButton.onClick.Invoke();
            yield return null;
            Assert.AreEqual("testuser", accountRepository.CurrentUserId);
            Assert.AreEqual("muttya_nagai_mojiretsu", accountRepository.CurrentUserToken);
        }
    }
}
