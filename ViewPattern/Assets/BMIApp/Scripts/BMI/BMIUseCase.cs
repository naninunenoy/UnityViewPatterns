using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace BMIApp.BMI {
    public class BMIUseCase<TEntity> : CleanArchitecture.IUseCase where TEntity : IBMIEntity, new() {
        readonly IBMIPresenter bmiPresenter;
        readonly IPushHistoryDelegate dataPushListener;
        readonly Component disposableComponent;

        public BMIUseCase(IBMIPresenter bmiPresenter,
                          IPushHistoryDelegate dataPushListener,
                          Component disposableComponent) {
            this.bmiPresenter = bmiPresenter;
            this.dataPushListener = dataPushListener;
            this.disposableComponent = disposableComponent;
        }

        public void Begin() {
            var entity = new TEntity();
            bmiPresenter.Begin();
            bmiPresenter
                .NameInput
                .Subscribe(x => {
                    entity.Name = x;
                })
                .AddTo(disposableComponent);
            bmiPresenter
                .HeightInput
                .Subscribe(x => {
                    if (float.TryParse(x, out var val)) {
                        entity.Height = val;
                    }
                })
                .AddTo(disposableComponent);
            bmiPresenter
                .WeightInput
                .Subscribe(x => {
                    if (float.TryParse(x, out var val)) {
                        entity.Weight = val;
                        entity.BMI = UpdateBMI(entity);
                    }
                })
                .AddTo(disposableComponent);
            bmiPresenter
                .AgeInput
                .Subscribe(x => {
                    if (int.TryParse(x, out var val)) {
                        entity.Age = val;
                        entity.BMI = UpdateBMI(entity);
                    }
                })
                .AddTo(disposableComponent);
            Observable
                .CombineLatest(bmiPresenter.GenderMaleSelect, bmiPresenter.GenderFemaleSelect)
                .Subscribe(x => {
                    if (x[0]) {
                        entity.Gender = Gender.Male;
                    } else if (x[1]) {
                        entity.Gender = Gender.Female;
                    } else {
                        entity.Gender = Gender.None;
                    }
                })
                .AddTo(disposableComponent);
            bmiPresenter
                .SaveButtonClickObservable
                .Subscribe(_ => {
                    entity.CreatedAt = DateTime.Now;
                    dataPushListener?.OnPushBMIEntity(entity);
                })
                .AddTo(disposableComponent);
            bmiPresenter.SetSaveButtonEnable(false);
        }

        float UpdateBMI(IBMIEntity entity) {
            if (!TryCalcBMI(entity.Height, entity.Weight, out float bmi)) {
                return 0.0F;
            }
            var msg = GetBMIEvaluation(bmi);
            bmiPresenter.SetBMIResult($"{bmi:F1}({msg})");
            bmiPresenter.SetSaveButtonEnable(true);
            return bmi;
        }

        bool TryCalcBMI(float heightCm, float weightKg, out float bmi) {
            if (heightCm <= 0.0F || weightKg <= 0.0F) {
                bmi = 0.0F;
                return false;
            }
            var h = heightCm / 100.0F; // m -> cm
            bmi = weightKg / (h * h);
            return true;
        }

        string GetBMIEvaluation(float bmi) {
            if (bmi < 16.0F) {
                return "やせすぎ";
            } else if (bmi < 17.0F) {
                return "やせ";
            } else if (bmi < 18.5F) {
                return "やせ気味";
            } else if (bmi < 25.0F) {
                return "普通";
            } else if (bmi < 30.0F) {
                return "肥満気味";
            } else {
                return "肥満";
            }
        }
    }
}
