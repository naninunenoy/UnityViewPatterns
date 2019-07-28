using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace BMIApp.BMI {
    public interface IAccountPresenter : CleanArchitecture.IPresenter {
        void Begin();
        IObservable<Unit> LogoutButtonClickObservable { get; }
        void SetAccountText(string text);
    }
}
