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

        IUseCase bmiUseCase;
        IUseCase historyUseCase;

        void Awake() {
            var historyDataStore = 
                string.IsNullOrEmpty(sharedData.CurrentUserId) ?
                (new TemporaryHistoryDataStore() as IHistoryDataStore<BMIEntity>):
                (new PlayerPrefsHistoryDataStore(sharedData.CurrentUserId) as IHistoryDataStore<BMIEntity>);
            // create UseCase
            historyUseCase = new HistoryUseCase<BMIEntity>(
                    new HistoryListPresenter(historyView, historyElmView),
                    new BMIHistoryRepository(historyDataStore),
                    this);
            bmiUseCase = new BMIUseCase<BMIEntity>(
                new BMIPresenter(bmiView),
                historyUseCase as IPushHistoryDelegate,
                this);
        }

        void Start() {
            // run UseCase
            bmiUseCase.Begin();
            historyUseCase.Begin();
        }
    }
}
