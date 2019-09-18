using UnityEngine;
using Zenject;

namespace BMIApp.Login {
    public class LoginSceneInstaller : MonoInstaller {
        [SerializeField] LoginView loginView = default;
        [SerializeField] AlertView loginAlertView = default;
        [SerializeField] SharedScriptableObject sharedData = default;

        public override void InstallBindings() {
            Container
                .Bind<IAuthController>()
                .FromInstance(new DummyAuthController())
                .AsCached()
                .IfNotBound();
            Container
                .Bind<ILoginPresenter>()
                .FromInstance(new LoginPresenter(loginView))
                .AsCached()
                .IfNotBound();
            Container
                .Bind<IAlertPresenter>()
                .FromInstance(new AlertPresenter(loginAlertView))
                .AsCached()
                .IfNotBound();
            Container
                .Bind<IUserAccountRepository>()
                .FromInstance(new UserAccountRepository(sharedData))
                .AsCached()
                .IfNotBound();
        }
    }
}
