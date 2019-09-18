using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using BMIApp.Login;

namespace BMIApp.Tests.PlayMode {
    public class AlertTestPresenter : IAlertPresenter {
        public AlertPresenter InnerPresenter { set; get; }

        public IObservable<Unit> CloseButtonClickObservable => InnerPresenter.CloseButtonClickObservable;

        public void Begin() {
            InnerPresenter?.Begin();
        }

        public void Close() {
            InnerPresenter?.Close();
        }

        public void Open(string message) {
            InnerPresenter?.Open(message);
        }
    }
}
