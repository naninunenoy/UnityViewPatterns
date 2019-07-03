using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;

namespace ViewPatterns.CA {
    public class BMIUseCase : IUseCase<IPresenter<BMIView>, IRepository<PersonEntity>> {
        private const int personMaxNameLength = 10;
        private readonly BMIPresenter presenter;
        private readonly PersonRepository repository;
        private readonly BMIModel model;

        public BMIUseCase(BMIPresenter presenter, PersonRepository repository) {
            this.presenter = presenter;
            this.repository = repository;
            model = new BMIModel();
        }

        public void Initialize() {
            var person = repository.GetEntity();
            // observe view update
            presenter
                .PersonNameInput
                .SkipLatestValueOnSubscribe()
                .Subscribe(x => {
                    var name = x;
                    if (name.Length > personMaxNameLength) {
                        // 名前は10文字までとする
                        name = string.Concat(name.Take(personMaxNameLength));
                        presenter.SetPersonName(name);
                    }
                    person.Name = name;
                    repository.SetEntity(person);
                });
            presenter
                .PersonAgeInput
                .SkipLatestValueOnSubscribe()
                .Subscribe(x => {
                    if (int.TryParse(x, out int age) && age >= 0) {
                        person.Age = age;
                        repository.SetEntity(person);
                    } else {
                        presenter.SetPersonAge(""); // 不正な入力は削除
                    }
                });
            presenter
                .PersonHeightInput
                .SkipLatestValueOnSubscribe()
                .Subscribe(x => {
                    if (float.TryParse(x, out float height) && height > 0.0F) {
                        person.Height = height;
                        repository.SetEntity(person);
                        CalcBMI(person);
                    } else {
                        presenter.SetPersonHeight(""); // 不正な入力は削除
                    }
                });
            presenter
                .PersonWeightInput
                .SkipLatestValueOnSubscribe()
                .Subscribe(x => {
                    if (float.TryParse(x, out float weight) && weight > 0.0F) {
                        person.Weight = weight;
                        repository.SetEntity(person);
                        CalcBMI(person);
                    } else {
                        presenter.SetPersonWeight(""); // 不正な入力は削除
                    }
                });
            presenter.Bind();
        }

        void CalcBMI(PersonEntity person) {
            var bmi = model.CalcBMI(person.Height, person.Weight);
            if (Mathf.Approximately(bmi, BMIModel.invalidBMI)) {
                return;
            }
            var eval = model.EvaluateBMI(bmi);
            // apply
            presenter.SetPersonBMI(bmi.ToString("F1"));
            presenter.SetPersonBMIEvaluation(eval.ToJpn());
        }
    }
}
