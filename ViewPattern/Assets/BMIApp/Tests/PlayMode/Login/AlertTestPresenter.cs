using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using BMIApp.Login;

namespace BMIApp.Tests.PlayMode {
    public class AlertTestPresenter : IAlertPresenter {
        public AlertView View { set; get; }

        public IObservable<Unit> CloseButtonClickObservable { private set; get; }

        public void Begin() {
            CloseButtonClickObservable = View.CloseButton.OnClickAsObservable();
        }

        public void Close() {
            View.ViewTransform.gameObject.SetActive(false);
        }

        public void Open(string message) {
            View.AlertText.text = message;
            View.ViewTransform.gameObject.SetActive(true);
        }
    }
}
