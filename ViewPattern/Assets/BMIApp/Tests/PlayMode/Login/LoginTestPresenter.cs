using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using BMIApp.Login;

namespace BMIApp.Tests.PlayMode {
    public class LoginTestPresenter : ILoginPresenter {
        public LoginView View { set; get; }

        public IReadOnlyReactiveProperty<string> IdInput { private set; get; }

        public IReadOnlyReactiveProperty<string> PasswordInput { private set; get; }

        public IObservable<Unit> LoginButtonClickObservable { private set; get; }

        public void SetLoginButtonInteractive(bool interactive) {
            if (View?.LoginButton != null) {
                View.LoginButton.interactable = interactive;
            }
        }

        public void Begin() {
            IdInput = View?.IdInputField.OnEndEditAsObservable().ToReadOnlyReactiveProperty();
            PasswordInput = View?.PasswordInputField.OnEndEditAsObservable().ToReadOnlyReactiveProperty();
            LoginButtonClickObservable = View?.LoginButton.OnClickAsObservable();
        }
    }
}
