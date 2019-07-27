using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace BMIApp.Login {
    public class AlertUseCase : CleanArchitecture.IUseCase, IAuthResultDelegate {
        readonly IAlertPresenter presenter;
        readonly Component disposableComponent;

        public AlertUseCase(IAlertPresenter presenter, Component component) {
            this.presenter = presenter;
            disposableComponent = component;
        }

        public void Begin() {
            presenter.Begin();
            presenter
                .CloseButtonClickObservable
                .Subscribe(_ => {
                    presenter.Close();
                })
                .AddTo(disposableComponent);
        }

        void IAuthResultDelegate.OnAuthFailure() {
            presenter.Open("アカウントIDまたはパスワードが正しくありません。\n入力をご確認ください。");
        }

        void IAuthResultDelegate.OnAuthSuccess() {
            // Do Nothing
        }
    }
}

