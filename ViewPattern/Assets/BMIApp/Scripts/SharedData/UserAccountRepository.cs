using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BMIApp {
    [Serializable]
    [CreateAssetMenu(menuName = "ScriptableObject/UserAccountRepository", fileName = "UserAccountRepository")]
    public class UserAccountRepository : ScriptableObject, IUserAccountRepository {
        [SerializeField] string currentUserId;
        [SerializeField] string currentUserToken;

        public string CurrentUserId { set { currentUserId = value; } get => currentUserId; }
        public string CurrentUserToken { set { currentUserToken = value; } get => currentUserToken; }

        public void Clear() {
            currentUserId = string.Empty;
            currentUserToken = string.Empty;
        }
    }
}
