using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BMIApp.Tests.PlayMode {
    public class UserAccountTestRepository : IUserAccountRepository {
        public SharedScriptableObject Data { set; get; }

        public string CurrentUserId { set { Data.CurrentUserId = value; } get => Data.CurrentUserId; }
        public string CurrentUserToken { set { Data.CurrentUserToken = value; } get => Data.CurrentUserToken; }

        public void Clear() {
            Data.CurrentUserId = string.Empty;
            Data.CurrentUserToken = string.Empty;
        }
    }
}
