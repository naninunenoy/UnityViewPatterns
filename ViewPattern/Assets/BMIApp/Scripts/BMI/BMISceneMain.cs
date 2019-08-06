using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BMIApp.CleanArchitecture;

namespace BMIApp.BMI {
    public class BMISceneMain : MonoBehaviour, ISceneMain {
        [SerializeField] SharedScriptableObject sharedData = default;
        [SerializeField] BMIView bmiView = default;

        IUseCase bmiUseCase;

        void Awake() {
            var historyDataStore = 
                string.IsNullOrEmpty(sharedData.CurrentUserId) ?
                (new TemporaryHistoryDataStore() as IHistoryDataStore<BMIEntity>):
                (new PlayerPrefsHistoryDataStore(sharedData.CurrentUserId) as IHistoryDataStore<BMIEntity>);
            bmiUseCase = new BMIUseCase<BMIEntity>(
                new BMIPresenter(bmiView),
                new BMIHistoryRepository(historyDataStore),
                this);
        }

        void Start() {
            bmiUseCase.Begin();
        }
    }
}
