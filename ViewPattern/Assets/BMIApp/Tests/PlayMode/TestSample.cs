using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class TestSample {
        System.Diagnostics.Stopwatch sw;

        [OneTimeSetUp]
        public void OneTimeSetUp() {
            sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            Debug.Log($"OneTimeSetUpTest t={sw.ElapsedMilliseconds}");
        }

        [SetUp]
        public void SetUpTest() {
            Debug.Log($"SetUpTest t={sw.ElapsedMilliseconds}");
        }

        [TearDown]
        public void TearDwonTest() {
            Debug.Log($"TearDwonTest t={sw.ElapsedMilliseconds}");
        }

        [OneTimeTearDown]
        public void OneTimeTearDownTest() {
            Debug.Log($"OneTimeTearDownTest t={sw.ElapsedMilliseconds}");
            sw.Stop();
        }

        [Test]
        public void DoTest2() {
            Debug.Log($"DoTest2 t={sw.ElapsedMilliseconds}");
        }

        [Test]
        public void DoTest1() {
            Debug.Log($"DoTest1 t={sw.ElapsedMilliseconds}");
        }

        [Test]
        [Order(-1)]
        public void DoTest99() {
            Debug.Log($"DoTest99 t={sw.ElapsedMilliseconds}");
        }

        [Test]
        [Order(1)]
        public void DoTest0() {
            Debug.Log($"DoTest0 t={sw.ElapsedMilliseconds}");
        }
    }
}
