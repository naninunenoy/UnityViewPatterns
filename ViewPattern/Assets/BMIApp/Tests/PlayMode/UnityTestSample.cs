using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class UnityTestSample {
        System.Diagnostics.Stopwatch sw;

        [OneTimeSetUp]
        //[OneTimeUnitySetUp]は無い
        public void OneTimeSetUp() {
            sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            Debug.Log($"OneTimeSetUpTest t={sw.ElapsedMilliseconds}");
        }
        
        [UnitySetUp]
        public IEnumerator SetUpTest() {
            Debug.Log($"SetUpUnityTest t={sw.ElapsedMilliseconds}");
            yield return null;
        }

        [UnityTearDown]
        public IEnumerator TearDownTest() {
            Debug.Log($"TearDownUnityTest t={sw.ElapsedMilliseconds}");
            yield return null;
        }

        [OneTimeTearDown]
        //[OneTimeUnityTearDown]は無い
        public void OneTimeTearDownTest() {
            Debug.Log($"OneTimeTearDownTest t={sw.ElapsedMilliseconds}");
            sw.Stop();
        }

        [UnityTest]
        public IEnumerator DoUnityTest2() {
            Debug.Log($"DoUnityTest2 t={sw.ElapsedMilliseconds}");
            yield return null;
        }

        [UnityTest]
        public IEnumerator DoUnityTest1() {
            Debug.Log($"DoUnityTest1 t={sw.ElapsedMilliseconds}");
            yield return null;
        }

        [UnityTest]
        [Order(-1)]
        public IEnumerator DoUnityTest99() {
            Debug.Log($"DoUnityTest99 t={sw.ElapsedMilliseconds}");
            yield return null;
        }

        [UnityTest]
        [Order(1)]
        public IEnumerator DoUnityTest0() {
            Debug.Log($"DoUnityTest99 t={sw.ElapsedMilliseconds}");
            yield return null;
        }
    }
}
