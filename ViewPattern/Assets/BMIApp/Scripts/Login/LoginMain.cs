using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using BMIApp.CleanArchitecture;

namespace BMIApp.Login {
    public class LoginMain : MonoBehaviour, ISceneMain {
        IUseCase authUseCase;
        IUseCase alertUseCase;
        IUseCase sceneUseCase;

        [Inject]
        void ConstructUseCases(IAuthController authController,
                               ILoginPresenter loginPresenter,
                               IAlertPresenter alertPresenter,
                               IUserAccountRepository userAccountRepository) {
            sceneUseCase = new SceneTransitionUseCase();
            alertUseCase = new AlertUseCase(alertPresenter, this);
            var authDelegates = new IAuthResultDelegate[] { 
                alertUseCase as IAuthResultDelegate, 
                sceneUseCase as IAuthResultDelegate };
            authUseCase = new AuthUseCase(loginPresenter, 
                                          authController, 
                                          userAccountRepository,
                                          authDelegates, this);
        }

        void Awake() {
            authUseCase.Begin();
            alertUseCase.Begin();
            sceneUseCase.Begin();
        }
    }
}
