using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace BMIApp.BMI {
    public class BMIPresenter : IBMIPresenter {
        readonly IBMIView view;
        public IReadOnlyReactiveProperty<string> NameInput { private set; get; }
        public IReadOnlyReactiveProperty<string> HeightInput { private set; get; }
        public IReadOnlyReactiveProperty<string> WeightInput { private set; get; }
        public IReadOnlyReactiveProperty<string> AgeInput { private set; get; }
        public IReadOnlyReactiveProperty<bool> GenderMaleSelect { private set; get; }
        public IReadOnlyReactiveProperty<bool> GenderFemaleSelect { private set; get; }
        public IObservable<Unit> SaveButtonClickObservable { private set; get; }

        public BMIPresenter(IBMIView view) { this.view = view; }

        public void Begin() {
            NameInput = view.NameInput.OnEndEditAsObservable().ToReadOnlyReactiveProperty();
            HeightInput = view.HeightInput.OnEndEditAsObservable().ToReadOnlyReactiveProperty();
            WeightInput = view.WeightInput.OnEndEditAsObservable().ToReadOnlyReactiveProperty();
            AgeInput = view.AgeInput.OnEndEditAsObservable().ToReadOnlyReactiveProperty();
            GenderMaleSelect = view.GenderMaleToggle.OnValueChangedAsObservable().ToReadOnlyReactiveProperty();
            GenderFemaleSelect = view.GenderFemaleToggle.OnValueChangedAsObservable().ToReadOnlyReactiveProperty();
            SaveButtonClickObservable = view.SaveButton.OnClickAsObservable();
        }

        public void SetBMIResult(string result) {
            view.BMIText.text = result;
        }

        public void SetSaveButtonEnable(bool enable) {
            view.SaveButton.interactable = enable;
        }
    }
}
