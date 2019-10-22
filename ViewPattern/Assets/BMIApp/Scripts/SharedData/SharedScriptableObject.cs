using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BMIApp {
    [Serializable]
    [CreateAssetMenu(menuName = "ScriptableObject/SharedScriptableObject", fileName = "SharedScriptableObject")]
    public class SharedScriptableObject : ScriptableObject, ISharedData {
        [SerializeField] string currentUserId;
        [SerializeField] string currentUserToken;
        public string CurrentUserId { get => currentUserId; set { currentUserId = value; } }
        public string CurrentUserToken { get => currentUserToken; set { currentUserToken = value; } }

        public SharedScriptableObject() {
            Clear();
        }

        public void Clear() {
            currentUserId = string.Empty;
            currentUserToken = string.Empty;
        }
    }
}
