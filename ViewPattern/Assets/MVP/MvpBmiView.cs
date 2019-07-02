using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace ViewPatterns.MVP {
    public interface IBMIViewUpdateDelegate {
        void OnNameInputChange(string personName);
        void OnAgeInputChange(string personAge);
        void OnHeightInputChange(string personHeight);
        void OnWeightInputChange(string personWeight);
    }

    public class MvpBmiView : BMIView {
        public void Bind(IBMIViewUpdateDelegate presenter, IReadOnlyBMIModel readOnlyModel) {
            // ユーザからの操作をpresenterに通知
            NameInputField.OnValueChangedAsObservable().Subscribe(presenter.OnNameInputChange).AddTo(this);
            AgeInputField.OnValueChangedAsObservable().Subscribe(presenter.OnAgeInputChange).AddTo(this);
            HeightInputField.OnValueChangedAsObservable().Subscribe(presenter.OnHeightInputChange).AddTo(this);
            WeightInputField.OnValueChangedAsObservable().Subscribe(presenter.OnWeightInputChange).AddTo(this);
            // Modelの更新をViewに反映
            readOnlyModel.PersonName.SubscribeToText(NameInputField.textComponent).AddTo(this);
            readOnlyModel.PersonAge.SubscribeToText(AgeInputField.textComponent).AddTo(this);
            readOnlyModel.PersonHeight.SubscribeToText(HeightInputField.textComponent).AddTo(this);
            readOnlyModel.PersonWeight.SubscribeToText(WeightInputField.textComponent).AddTo(this);
            readOnlyModel.PersonBMIValue.SubscribeToText(BMIValueText).AddTo(this);
            readOnlyModel.PersonBMIEval.Subscribe(x => { BMIEvaluateText.text = x.ToJpn(); }).AddTo(this);
        }
    }
}
