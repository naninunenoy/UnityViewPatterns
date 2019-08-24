using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BMIApp.CleanArchitecture;

namespace BMIApp.BMI {
    public class BMISceneMain : MonoBehaviour, ISceneMain {
        [SerializeField] SharedScriptableObject sharedData = default;
        [SerializeField] BMIView bmiView = default;
        [SerializeField] HistoryView historyView = default;
        [SerializeField] HistoryElmView historyElmView = default;
        [SerializeField] AccountView accountView = default;

        IUseCase bmiUseCase;
        IUseCase historyUseCase;
        IUseCase logoutUseCase;

        void Awake() {
            var historyDataStore = 
                string.IsNullOrEmpty(sharedData.CurrentUserId) ?
                (new TemporaryHistoryDataStore() as IHistoryDataStore):
                (new PlayerPrefsHistoryDataStore(sharedData.CurrentUserId) as IHistoryDataStore);
            // create UseCase
            historyUseCase = new HistoryUseCase(
                    new HistoryListPresenter(historyView, historyElmView),
                    new BMIHistoryRepository(historyDataStore),
                    this);
            bmiUseCase = new BMIUseCase<BMIEntity>(
                new BMIPresenter(bmiView),
                historyUseCase as IPushHistoryDelegate,
                this);
            logoutUseCase = new LogoutUseCase(
                new UserAccountRepository(sharedData),
                new AccountPresenter(accountView),
                this);
        }

        void Start() {
            // run UseCase
            bmiUseCase.Begin();
            historyUseCase.Begin();
            logoutUseCase.Begin();
        }
    }
}
