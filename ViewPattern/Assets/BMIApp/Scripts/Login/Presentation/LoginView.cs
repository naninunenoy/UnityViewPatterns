using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BMIApp.Login {
    public class LoginView : MonoBehaviour, ILoginView {
        [SerializeField] InputField idInputField = default;
        [SerializeField] InputField pwInputField = default;
        [SerializeField] Button loginButton = default;

        InputField ILoginView.IdInputField => idInputField;

        InputField ILoginView.PasswordInputField => pwInputField;

        Button ILoginView.LoginButton => loginButton;
    }
}
