using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace BMIApp.Login {
    public class LoginPresenter : ILoginPresenter {
        IReadOnlyReactiveProperty<string> ILoginPresenter.IdInput => throw new NotImplementedException();

        IReadOnlyReactiveProperty<string> ILoginPresenter.PasswordInput => throw new NotImplementedException();

        IObservable<Unit> ILoginPresenter.LoginButtonClickObservable => throw new NotImplementedException();

        void ILoginPresenter.SetLoginButtonInteractive(bool interactive) {
            throw new NotImplementedException();
        }
    }
}
