using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace BMIApp.Login {
    public interface ILoginPresenter : CleanArchitecture.IPresenter {
        IReadOnlyReactiveProperty<string> IdInput { get; }
        IReadOnlyReactiveProperty<string> PasswordInput { get; }
        IObservable<Unit> LoginButtonClickObservable { get; }
        void SetLoginButtonInteractive(bool interactive);
    }
}
