using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using BMIApp.BMI;

namespace BMIApp.Tests.PlayMode {
    public class BMITestPresenter : IBMIPresenter {
        public BMIPresenter InnerPresenter { set; get; }

        public IReadOnlyReactiveProperty<string> NameInput => InnerPresenter.NameInput;

        public IReadOnlyReactiveProperty<string> HeightInput => InnerPresenter.HeightInput;

        public IReadOnlyReactiveProperty<string> WeightInput => InnerPresenter.WeightInput;

        public IReadOnlyReactiveProperty<string> AgeInput => InnerPresenter.AgeInput;

        public IReadOnlyReactiveProperty<bool> GenderMaleSelect => InnerPresenter.GenderMaleSelect;

        public IReadOnlyReactiveProperty<bool> GenderFemaleSelect => InnerPresenter.GenderFemaleSelect;

        public IObservable<Unit> SaveButtonClickObservable => InnerPresenter.SaveButtonClickObservable;

        public void Begin() {
            InnerPresenter.Begin();
        }

        public void SetBMIResult(string result) {
            InnerPresenter.SetBMIResult(result);
        }

        public void SetSaveButtonEnable(bool enable) {
            InnerPresenter.SetSaveButtonEnable(enable);
        }
    }
}
