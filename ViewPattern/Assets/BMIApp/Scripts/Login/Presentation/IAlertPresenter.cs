using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace BMIApp.Login {
    public interface IAlertPresenter : CleanArchitecture.IPresenter {
        IObservable<Unit> CloseButtonClickObservable { get; }
        void Begin();
        void Open(string message);
        void Close();
    }
}
