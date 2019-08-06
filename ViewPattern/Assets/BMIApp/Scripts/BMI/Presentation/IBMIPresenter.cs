using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace BMIApp.BMI {
    public interface IBMIPresenter : CleanArchitecture.IPresenter {
        void Begin();
        IReadOnlyReactiveProperty<string> NameInput { get; }
        IReadOnlyReactiveProperty<string> HeightInput { get; }
        IReadOnlyReactiveProperty<string> WeightInput { get; }
        IReadOnlyReactiveProperty<string> AgeInput { get; }
        IReadOnlyReactiveProperty<bool> GenderMaleSelect { get; }
        IReadOnlyReactiveProperty<bool> GenderFemaleSelect { get; }
        IObservable<Unit> SaveButtonClickObservable { get; }
        void SetBMIResult(string result);
        void SetSaveButtonEnable(bool enable);
    }
}
