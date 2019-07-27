using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BMIApp.Login {
    public class LoginView : MonoBehaviour, ILoginView {
        InputField ILoginView.IdInputField => throw new System.NotImplementedException();

        InputField ILoginView.PasswordInputField => throw new System.NotImplementedException();

        Button ILoginView.LoginButton => throw new System.NotImplementedException();
    }
}
