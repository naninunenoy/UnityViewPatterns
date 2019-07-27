using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using UnityEngine;

namespace BMIApp.Login {
    public class DummyAuthController : IAuthController {
        struct User {
            public string id;
            public string password;
            public string token;
        }

        readonly User dummyUser1 = new User { id = "tanaka", password = "tanaka", token = "tanaka" };
        readonly User dummyUser2 = new User { id = "testuser", password = "password123", token = "muttya_nagai_mojiretsu" };
        readonly Dictionary<string, User> authUsers;

        public DummyAuthController() {
            var users = new User[] { dummyUser1, dummyUser2 };
            authUsers = users.ToDictionary(x => x.id);
        }

        public async Task<string> TryGetTokenAsync(string id, string password) {
            if (!authUsers.TryGetValue("id", out User user) || user.password != password)  {
                return string.Empty;
            }
            return await Task.FromResult(user.token);
        }
    }
}
