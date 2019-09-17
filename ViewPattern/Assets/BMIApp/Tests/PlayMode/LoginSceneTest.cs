using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Zenject;
using BMIApp.Login;

namespace BMIApp.Tests.PlayMode {
    [TestFixture]
    public class LoginSceneTest : ZenjectIntegrationTestFixture {
        const string sceneName = "Login";

        [UnityTest]
        public IEnumerator SceneTest() {
            yield return null;
        }
    }
}
