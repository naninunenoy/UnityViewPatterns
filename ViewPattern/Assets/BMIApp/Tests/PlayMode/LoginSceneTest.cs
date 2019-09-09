using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using BMIApp.Login;

namespace BMIApp.Tests.PlayMode {
    public class LoginSceneTest {
        LoginMain main = default;

        [UnitySetUp]
        public IEnumerator SetUpTest() {
            var load = SceneManager.LoadSceneAsync("Login");
            while (!load.isDone) {
                yield return null;
            }
        }

        [UnityTearDown]
        public IEnumerator TearDownTest() {
            main = default;
            yield return null;
        }

        [UnityTest]
        public IEnumerator FindMainTest() {
            main = GameObject.Find("LoginMain").GetComponent<LoginMain>();
            Assert.IsNotNull(main);
            yield return null;
        }
    }
}
