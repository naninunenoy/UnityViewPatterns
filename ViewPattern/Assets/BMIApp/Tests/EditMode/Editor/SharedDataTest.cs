using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace BMIApp.Tests.EditMode {
    public class SharedDataTest {
        [Test]
        public void SharedScriptableObjectTest() {
            var obj = ScriptableObject.CreateInstance<SharedScriptableObject>();
            Assert.NotNull(obj);
            Assert.IsInstanceOf<ISharedData>(obj);
            Assert.IsEmpty(obj.CurrentUserId);
            Assert.IsEmpty(obj.CurrentUserToken);
            obj.CurrentUserId = "test_id";
            obj.CurrentUserToken = "test_token";
            Assert.That(obj.CurrentUserId, Is.EqualTo("test_id"));
            Assert.That(obj.CurrentUserToken, Is.EqualTo("test_token"));
        }

        [Test]
        public void UserAccountRepositoryTest() {
            var rep = new UserAccountRepository(ScriptableObject.CreateInstance<SharedScriptableObject>());
            Assert.NotNull(rep);
            Assert.IsInstanceOf<IUserAccountRepository>(rep);
            Assert.IsEmpty(rep.CurrentUserId);
            Assert.IsEmpty(rep.CurrentUserToken);
            rep.CurrentUserId = "test_id";
            rep.CurrentUserToken = "test_token";
            Assert.That(rep.CurrentUserId, Is.EqualTo("test_id"));
            Assert.That(rep.CurrentUserToken, Is.EqualTo("test_token"));
        }
    }
}
