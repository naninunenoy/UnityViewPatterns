using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using BMIApp.CleanArchitecture;

namespace BMIApp.BMI {
    public class BMISceneMain : MonoBehaviour, ISceneMain {
        IUseCase bmiUseCase;
        IUseCase historyUseCase;
        IUseCase logoutUseCase;

        [Inject]
        void ConstructUseCases(IHistoryListPresenter historyListPresenter,
                               IBMIHistoryRepository historyRepository,
                               IBMIPresenter bmiPresenter,
                               IUserAccountRepository userAccountRepository,
                               IAccountPresenter accountPresenter) {
            historyUseCase = new HistoryUseCase(
                historyListPresenter, 
                historyRepository, 
                this);
            bmiUseCase = new BMIUseCase<BMIDataTransferObject>(
                bmiPresenter,
                historyUseCase as IPushHistoryDelegate,
                this);
            logoutUseCase = new LogoutUseCase(
                userAccountRepository,
                accountPresenter,
                this);
        }

        void Awake() {
            // run UseCase
            bmiUseCase.Begin();
            historyUseCase.Begin();
            logoutUseCase.Begin();
        }
    }
}
