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

        [UnityTest]
        public IEnumerator SceneTest() {
            // Install binding for test
            StaticContext.Container.Bind<ITest>().To<Test>().AsTransient();
            // Load scene
            yield return LoadScene(sceneName);
            // Find views from Scene
            var view = GameObject.Find("MyViewOnScene");
            // Run Main
            GameObject.Find("SceneContext").GetComponent<IMainInstaller>().SceneMainObject.SetActive(true);
            // Assert
        }
    }
}
