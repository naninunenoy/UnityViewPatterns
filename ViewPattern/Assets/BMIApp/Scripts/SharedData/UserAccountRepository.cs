using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BMIApp {
    public class UserAccountRepository : IUserAccountRepository {
        readonly ISharedData data;

        public UserAccountRepository(ISharedData data) { this.data = data; }

        public string CurrentUserId { set { data.CurrentUserId = value; } get => data.CurrentUserId;  }
        public string CurrentUserToken { set { data.CurrentUserToken = value; } get => data.CurrentUserToken; }

        public void Clear() {
            data.CurrentUserId = string.Empty;
            data.CurrentUserToken = string.Empty;
        }
    }
}
