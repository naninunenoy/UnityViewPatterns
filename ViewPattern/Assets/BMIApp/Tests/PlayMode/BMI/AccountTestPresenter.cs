using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using BMIApp.BMI;

namespace BMIApp.Tests.PlayMode {
    public class AccountTestPresenter : IAccountPresenter {
        public AccountPresenter InnerPresenter { set; get; }

        public IObservable<Unit> LogoutButtonClickObservable => InnerPresenter.LogoutButtonClickObservable;

        public void Begin() {
            InnerPresenter.Begin();
        }

        public void SetAccountText(string text) {
            InnerPresenter.SetAccountText(text);
        }
    }
}
