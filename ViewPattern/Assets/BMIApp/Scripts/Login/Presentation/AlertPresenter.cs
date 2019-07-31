using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace BMIApp.Login {
    public class AlertPresenter : IAlertPresenter {
        readonly IAlertView view;
        public AlertPresenter(IAlertView view) { this.view = view; }

        public IObservable<Unit> CloseButtonClickObservable { private set; get; }

        public void Begin() {
            CloseButtonClickObservable = view.CloseButton.OnClickAsObservable();
        }

        public void Close() {
            view.ViewTransform.gameObject.SetActive(false);
        }

        public void Open(string message) {
            view.AlertText.text = message;
            view.ViewTransform.gameObject.SetActive(true);
        }
    }
}
