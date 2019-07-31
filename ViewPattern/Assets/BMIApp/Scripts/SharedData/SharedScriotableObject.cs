using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BMIApp {
    [Serializable]
    [CreateAssetMenu(menuName = "ScriptableObject/SharedScriotableObject", fileName = "SharedScriotableObject")]
    public class SharedScriotableObject : ScriptableObject, ISharedData {
        [SerializeField] string currentUserId;
        [SerializeField] string currentUserToken;
        public string CurrentUserId { get => currentUserId; set { currentUserId = value; } }
        public string CurrentUserToken { get => currentUserToken; set { currentUserToken = value; } }

        public void Clear() {
            currentUserId = string.Empty;
            currentUserToken = string.Empty;
        }
    }
}
