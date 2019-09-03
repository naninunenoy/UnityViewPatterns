using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using BMIApp.Login;

namespace BMIApp.Tests.EditMode {
    public class LoginTest {
        [Test]
        public void DummyAuthControllerTest() {
            var ctr = new DummyAuthController();
            Assert.NotNull(ctr);
            Assert.IsInstanceOf<IAuthController>(ctr);
            var tkn = ctr.TryGetTokenAsync("", "").Result;
            Assert.That(tkn, Is.Empty);
            tkn = ctr.TryGetTokenAsync("tanaka", "tanaka").Result;
            Assert.That(tkn, Is.EqualTo("tanaka"));
            tkn = ctr.TryGetTokenAsync("testuser", "password").Result;
            Assert.That(tkn, !Is.EqualTo("muttya_nagai_mojiretsu"));
            tkn = ctr.TryGetTokenAsync("testuser", "password123").Result;
            Assert.That(tkn, Is.EqualTo("muttya_nagai_mojiretsu"));
        }
    }
}
