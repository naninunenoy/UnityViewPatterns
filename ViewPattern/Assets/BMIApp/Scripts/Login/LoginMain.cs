using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BMIApp.CleanArchitecture;

namespace BMIApp.Login {
    public class LoginMain : MonoBehaviour, ISceneMain {
        [SerializeField] LoginView loginView = default;
        [SerializeField] AlertView loginAlertView = default;
        [SerializeField] SharedScriptableObject sharedData = default;

        IUseCase authUseCase;
        IUseCase alertUseCase;
        IUseCase sceneUseCase;

        void Awake() {
            var authPresenter = new LoginPresenter(loginView);
            var alertPresenter = new AlertPresenter(loginAlertView);
            var auth = new DummyAuthController();
            // create usecase
            var scene = new SceneTransitionUseCase();
            var alert = new AlertUseCase(alertPresenter, this);
            authUseCase = new AuthUseCase(authPresenter, auth, 
                new UserAccountRepository(sharedData),
                new IAuthResultDelegate[] { scene, alert }, this);
            alertUseCase = alert;
            sceneUseCase = scene;
        }

        // Start is called before the first frame update
        void Start() {
            authUseCase.Begin();
            alertUseCase.Begin();
            sceneUseCase.Begin();
        }
    }
}
