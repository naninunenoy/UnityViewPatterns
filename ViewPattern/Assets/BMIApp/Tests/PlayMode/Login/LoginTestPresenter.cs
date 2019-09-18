using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using BMIApp.Login;

namespace BMIApp.Tests.PlayMode {
    public class LoginTestPresenter : ILoginPresenter {
        public LoginPresenter InnerPresenter { set; get; }

        public IReadOnlyReactiveProperty<string> IdInput => InnerPresenter.IdInput;
        public IReadOnlyReactiveProperty<string> PasswordInput => InnerPresenter.PasswordInput;
        public IObservable<Unit> LoginButtonClickObservable => InnerPresenter.LoginButtonClickObservable;

        public void SetLoginButtonInteractive(bool interactive) {
            InnerPresenter?.SetLoginButtonInteractive(interactive);
        }

        public void Begin() {
            InnerPresenter?.Begin();
        }
    }
}
