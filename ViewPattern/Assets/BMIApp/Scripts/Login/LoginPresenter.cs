using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace BMIApp.Login {
    public class LoginPresenter : ILoginPresenter {
        readonly ILoginView view;

        public LoginPresenter(ILoginView view) { this.view = view; }

        public IReadOnlyReactiveProperty<string> IdInput { private set; get; }

        public IReadOnlyReactiveProperty<string> PasswordInput { private set; get; }

        public IObservable<Unit> LoginButtonClickObservable { private set; get; }

        public void SetLoginButtonInteractive(bool interactive) {
            if (view?.LoginButton != null) {
                view.LoginButton.interactable = interactive;
            }
        }

        public void Begin() {
            IdInput = view?.IdInputField.OnEndEditAsObservable().ToReadOnlyReactiveProperty();
            PasswordInput = view?.PasswordInputField.OnEndEditAsObservable().ToReadOnlyReactiveProperty();
            LoginButtonClickObservable = view?.LoginButton.OnClickAsObservable();
        }
    }
}
