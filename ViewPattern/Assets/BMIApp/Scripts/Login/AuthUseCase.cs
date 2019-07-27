using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using UnityEngine;
using UniRx;

namespace BMIApp.Login {
    public class AuthUseCase : CleanArchitecture.IUseCase {
        readonly ILoginPresenter presenter;
        readonly IAuthController auth;
        readonly IUserAccountRepository repository;
        readonly Component disposableComponent;
        readonly IEnumerable<IAuthResultDelegate> authDelegates;

        public AuthUseCase(ILoginPresenter presenter, IAuthController auth, IUserAccountRepository repository,
                           IEnumerable<IAuthResultDelegate> authDelegates, Component disposableComponent) {
            this.presenter = presenter;
            this.auth = auth;
            this.repository = repository;
            this.authDelegates = authDelegates;
            this.disposableComponent = disposableComponent;
        }

        public void Begin() {
            presenter.Begin();
            // 未入力時はボタンを押せなくする
            Observable
                .ZipLatest(presenter.IdInput, presenter.PasswordInput)
                .Subscribe(x => {
                    bool contatinsEmpty = x.Any(y => string.IsNullOrEmpty(y));
                    presenter.SetLoginButtonInteractive(contatinsEmpty);
                })
                .AddTo(disposableComponent);
            // ログイン試行
            presenter
                .LoginButtonClickObservable
                .Subscribe(async _ => {
                    var success = await TryLoginAsync(presenter.IdInput.Value, presenter.PasswordInput.Value);
                    if (success) {
                        foreach (var e in authDelegates) { e.OnAuthSuccess(); }
                    } else {
                        foreach (var e in authDelegates) { e.OnAuthFailure(); }
                    }
                })
                .AddTo(disposableComponent);
            presenter.SetLoginButtonInteractive(false);
        }

        async Task<bool> TryLoginAsync(string id, string pw) {
            var token = await auth.TryGetTokenAsync(id, pw);
            if (!string.IsNullOrEmpty(token)) {
                return false;
            }
            // 認証の結果を保持
            repository.CurrentUserId = id;
            repository.CurrentUserToken = token;
            return true;
        }
    }
}
