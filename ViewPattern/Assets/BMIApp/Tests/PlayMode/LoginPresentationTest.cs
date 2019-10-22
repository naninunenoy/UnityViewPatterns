using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using BMIApp.Login;

namespace BMIApp.Tests.PlayMode {
    public class LoginPresentationTest {

        [UnityTest]
        public IEnumerator LoginViewTest() {
            var obj = new GameObject("view");
            var view = obj.AddComponent<LoginView>();
            Assert.NotNull(view);
            Assert.IsInstanceOf<ILoginView>(view);
            yield return null;
        }

        [UnityTest]
        public IEnumerator LoginPresenterTest() {
            var obj = new GameObject("view");
            var view = obj.AddComponent<LoginView>();
            var pre = new LoginPresenter(view);
            Assert.NotNull(pre);
            Assert.IsInstanceOf<ILoginPresenter>(pre);
            yield return null;
        }

        [UnityTest]
        public IEnumerator AlertViewTest() {
            var obj = new GameObject("view");
            var view = obj.AddComponent<AlertView>();
            Assert.NotNull(view);
            Assert.IsInstanceOf<IAlertView>(view);
            yield return null;
        }

        [UnityTest]
        public IEnumerator AlertPresenterTest() {
            var obj = new GameObject("view");
            var view = obj.AddComponent<AlertView>();
            var pre = new AlertPresenter(view);
            Assert.NotNull(pre);
            Assert.IsInstanceOf<IAlertPresenter>(pre);
            yield return null;
        }
    }
}
