using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace BMIApp.BMI {
    public class AccountPresenter : IAccountPresenter {
        readonly IAccountView view;
        public IObservable<Unit> LogoutButtonClickObservable { private set; get; }

        public AccountPresenter(IAccountView view) { this.view = view; }

        public void Begin() {
            LogoutButtonClickObservable  = view.LogoutButton.OnClickAsObservable();
        }

        public void SetAccountText(string text) {
            view.AccountNameText.text = text;
        }
    }
}
