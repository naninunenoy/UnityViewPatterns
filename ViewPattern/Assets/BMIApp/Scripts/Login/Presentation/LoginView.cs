using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BMIApp.Login {
    public class LoginView : MonoBehaviour, ILoginView {
        [SerializeField] InputField idInputField = default;
        [SerializeField] InputField pwInputField = default;
        [SerializeField] Button loginButton = default;

        public InputField IdInputField => idInputField;

        public InputField PasswordInputField => pwInputField;

        public Button LoginButton => loginButton;
    }
}
