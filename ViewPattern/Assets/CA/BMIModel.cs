using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace ViewPatterns.CA {
    public interface IReadOnlyBMIModel : IModel {
        IReadOnlyReactiveProperty<string> PersonName { get; }
        IReadOnlyReactiveProperty<int> PersonAge { get; }
        IReadOnlyReactiveProperty<float> PersonHeight { get; }
        IReadOnlyReactiveProperty<float> PersonWeight { get; }
        IReadOnlyReactiveProperty<float> PersonBMIValue { get; }
        IReadOnlyReactiveProperty<BMIEvalType> PersonBMIEval { get; }
    }

    public class BMIModel : IReadOnlyBMIModel {
        public IReactiveProperty<string> PersonName { get; }
        public IReactiveProperty<int> PersonAge { get; }
        public IReactiveProperty<float> PersonHeight { get; }
        public IReactiveProperty<float> PersonWeight { get; }
        public IReactiveProperty<float> PersonBMIValue { get; }
        public IReactiveProperty<BMIEvalType> PersonBMIEval { get; }

        public BMIModel(PersonEntity person) {
            PersonName = new ReactiveProperty<string> { Value = person.Name };
            PersonAge = new ReactiveProperty<int> { Value = person.Age };
            PersonHeight = new ReactiveProperty<float> { Value = person.Height };
            PersonWeight = new ReactiveProperty<float> { Value = person.Weight };
            PersonBMIValue = new ReactiveProperty<float>();
            PersonBMIEval = new ReactiveProperty<BMIEvalType>();
        }

        public void Initialize() {
            // 体重or身長の更新でBMI計算
            Observable
                .CombineLatest(PersonHeight, PersonWeight)
                .Subscribe(_ => {
                    var h = PersonHeight.Value / 100.0F; // cm -> m
                    var w = PersonWeight.Value;
                    if (!Mathf.Approximately(h, 0.0F)) {
                        PersonBMIValue.Value = w / (h * h);
                    }
                });
            // BMIの更新で評価も更新
            PersonBMIValue.Subscribe(x => {
                PersonBMIEval.Value = Evaluate(x);
            });
        }

        private BMIEvalType Evaluate(float bmi) {
            if (bmi <= 0.0F) {
                return BMIEvalType.Unknown;
            } else if (/*0.0F <= bmi &&*/ bmi < 15.0F) {
                return BMIEvalType.VerySeverelyUnderweight;
            } else if (15.0 <= bmi && bmi < 16.0F) {
                return BMIEvalType.SeverelyUnderweight;
            } else if (16.0 <= bmi && bmi < 18.5F) {
                return BMIEvalType.Underweight;
            } else if (18.5 <= bmi && bmi < 25.0F) {
                return BMIEvalType.Normal;
            } else if (25.0 <= bmi && bmi < 30.0F) {
                return BMIEvalType.Overweight;
            } else  /* if (bmi <= 30.0F) */ {
                return BMIEvalType.Moderately;
            }
        }

        IReadOnlyReactiveProperty<string> IReadOnlyBMIModel.PersonName => PersonName;
        IReadOnlyReactiveProperty<int> IReadOnlyBMIModel.PersonAge => PersonAge;
        IReadOnlyReactiveProperty<float> IReadOnlyBMIModel.PersonHeight => PersonHeight;
        IReadOnlyReactiveProperty<float> IReadOnlyBMIModel.PersonWeight => PersonWeight;
        IReadOnlyReactiveProperty<float> IReadOnlyBMIModel.PersonBMIValue => PersonBMIValue;
        IReadOnlyReactiveProperty<BMIEvalType> IReadOnlyBMIModel.PersonBMIEval => PersonBMIEval;
    }
}
