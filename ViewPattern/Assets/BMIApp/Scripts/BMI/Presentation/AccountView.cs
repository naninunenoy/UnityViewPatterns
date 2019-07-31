using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BMIApp.BMI {
    public class AccountView : MonoBehaviour, IAccountView {
        [SerializeField] Button logoutButton = default;
        [SerializeField] Text accountNameText = default;

        public Button LogoutButton => logoutButton;
        public Text AccountNameText => accountNameText;
    }
}
