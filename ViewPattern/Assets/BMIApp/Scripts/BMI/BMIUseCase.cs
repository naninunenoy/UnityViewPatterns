using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace BMIApp.BMI {
    public class BMIUseCase<TData> : CleanArchitecture.IUseCase where TData : IBMIDataTransferObject, new() {
        readonly IBMIDomain bmiDomain;
        readonly TData data;
        readonly IBMIPresenter bmiPresenter;
        readonly IPushHistoryDelegate dataPushListener;
        readonly Component disposableComponent;

        public BMIUseCase(IBMIPresenter bmiPresenter,
                          IPushHistoryDelegate dataPushListener,
                          Component disposableComponent) {
            bmiDomain = new BMIDomain();
            data = new TData();
            this.bmiPresenter = bmiPresenter;
            this.dataPushListener = dataPushListener;
            this.disposableComponent = disposableComponent;
        }

        public void Begin() {
            bmiPresenter.Begin();
            bmiPresenter
                .NameInput
                .Subscribe(x => {
                    data.Name = x;
                    bmiPresenter.SetSaveButtonEnable(CheckValidation(data));
                })
                .AddTo(disposableComponent);
            bmiPresenter
                .HeightInput
                .Subscribe(x => {
                    if (float.TryParse(x, out var val)) {
                        data.Height = val;
                    }
                })
                .AddTo(disposableComponent);
            bmiPresenter
                .WeightInput
                .Subscribe(x => {
                    if (float.TryParse(x, out var val)) {
                        data.Weight = val;
                        data.BMI = UpdateBMI(data);
                        bmiPresenter.SetSaveButtonEnable(CheckValidation(data));
                    }
                })
                .AddTo(disposableComponent);
            bmiPresenter
                .AgeInput
                .Subscribe(x => {
                    if (int.TryParse(x, out var val)) {
                        data.Age = val;
                        data.BMI = UpdateBMI(data);
                        bmiPresenter.SetSaveButtonEnable(CheckValidation(data));
                    }
                })
                .AddTo(disposableComponent);
            Observable
                .CombineLatest(bmiPresenter.GenderMaleSelect, bmiPresenter.GenderFemaleSelect)
                .Subscribe(x => {
                    if (x[0]) {
                        data.Gender = Gender.Male;
                    } else if (x[1]) {
                        data.Gender = Gender.Female;
                    } else {
                        data.Gender = Gender.None;
                    }
                })
                .AddTo(disposableComponent);
            bmiPresenter
                .SaveButtonClickObservable
                .Subscribe(_ => {
                    data.CreatedAt = DateTime.Now;
                    dataPushListener?.OnPushBMIData(data);
                })
                .AddTo(disposableComponent);
            bmiPresenter.SetSaveButtonEnable(false);
        }

        float UpdateBMI(IBMIDataTransferObject data) {
            var bmi = bmiDomain.CalcBMI(data);
            var msg = bmiDomain.EvaluateBMI(data);
            bmiPresenter.SetBMIResult($"{bmi:F1}({msg})");
            return bmi;
        }

        bool CheckValidation(IBMIDataTransferObject data) {
            return !string.IsNullOrWhiteSpace(data.Name) && data.BMI > 0.0F;
        }
    }
}
