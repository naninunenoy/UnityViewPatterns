using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace BMIApp.Tests {
    public class SharedDataTest {
        [Test]
        public void SharedScriptableObjectTest() {
            var obj = ScriptableObject.CreateInstance<SharedScriptableObject>();
            Assert.NotNull(obj);
            Assert.IsEmpty(obj.CurrentUserId);
            Assert.IsEmpty(obj.CurrentUserToken);
            obj.CurrentUserId = "test_id";
            obj.CurrentUserToken = "test_token";
            Assert.That(obj.CurrentUserId, Is.EqualTo("test_id"));
            Assert.That(obj.CurrentUserToken, Is.EqualTo("test_token"));
        }

        [Test]
        public void UserAccountRepositoryTest() {
            var obj = ScriptableObject.CreateInstance<SharedScriptableObject>();
            var rep = new UserAccountRepository(obj);
            Assert.NotNull(rep);
            Assert.IsEmpty(rep.CurrentUserId);
            Assert.IsEmpty(rep.CurrentUserToken);
            rep.CurrentUserId = "test_id";
            rep.CurrentUserToken = "test_token";
            Assert.That(rep.CurrentUserId, Is.EqualTo("test_id"));
            Assert.That(rep.CurrentUserToken, Is.EqualTo("test_token"));
        }
    }
}
