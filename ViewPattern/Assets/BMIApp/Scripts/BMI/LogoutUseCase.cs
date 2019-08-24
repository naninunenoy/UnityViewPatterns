using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;

namespace BMIApp.BMI {
    public class LogoutUseCase : CleanArchitecture.IUseCase {
        readonly IUserAccountRepository repository;
        readonly IAccountPresenter presenter;
        readonly Component disposablesComponent;

        public LogoutUseCase(IUserAccountRepository repository, IAccountPresenter presenter,
                             Component disposablesComponent) {
            this.repository = repository;
            this.presenter = presenter;
            this.disposablesComponent = disposablesComponent;
        }

        public void Begin() {
            presenter.Begin();
            var name = string.IsNullOrEmpty(repository?.CurrentUserId) ? "???" : repository.CurrentUserId;
            presenter.SetAccountText($"{name}としてログイン");
            presenter
                .LogoutButtonClickObservable
                .Subscribe(_ => {
                    // ログアウト前にデータリセット
                    repository.Clear();
                    SceneManager.LoadScene("Login");
                })
                .AddTo(disposablesComponent);
        }
    }
}
