using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;

namespace ViewPatterns.CA {
    public class BMIPresenter : IPresenter<BMIView> {
        private readonly BMIView view;
        private readonly ReactiveProperty<string> personNameInput;
        private readonly ReactiveProperty<string> personAgeInput;
        private readonly ReactiveProperty<string> personHeightInput;
        private readonly ReactiveProperty<string> personWeightInput;

        public BMIPresenter(BMIView view) {
            personNameInput = new ReactiveProperty<string>();
            personAgeInput = new ReactiveProperty<string>();
            personHeightInput = new ReactiveProperty<string>();
            personWeightInput = new ReactiveProperty<string>();
            this.view = view;
        }

        public void Bind() {
            view.NameInputField.OnValueChangedAsObservable().Subscribe(x => { personNameInput.Value = x; });
            view.AgeInputField.OnValueChangedAsObservable().Subscribe(x => { personAgeInput.Value = x; });
            view.HeightInputField.OnValueChangedAsObservable().Subscribe(x => { personHeightInput.Value = x; });
            view.WeightInputField.OnValueChangedAsObservable().Subscribe(x => { personWeightInput.Value = x; });
        }

        public IReadOnlyReactiveProperty<string> PersonNameInput { get => personNameInput; }
        public IReadOnlyReactiveProperty<string> PersonAgeInput { get => personAgeInput; }
        public IReadOnlyReactiveProperty<string> PersonHeightInput { get => personHeightInput; }
        public IReadOnlyReactiveProperty<string> PersonWeightInput { get => personWeightInput; }

        public void SetPersonName(string name) { view.NameInputField.text = name; }
        public void SetPersonAge(string age) { view.AgeInputField.text = age; }
        public void SetPersonHeight(string height) { view.HeightInputField.text = height; }
        public void SetPersonWeight(string weight) { view.WeightInputField.text = weight; }
        public void SetPersonBMI(string bmi) { view.BMIValueText.text = bmi; }
        public void SetPersonBMIEvaluation(string eval) { view.BMIEvaluateText.text = eval; }
    }
}
