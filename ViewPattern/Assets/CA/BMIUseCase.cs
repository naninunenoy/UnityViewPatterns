using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;

namespace ViewPatterns.CA {
    public class BMIUseCase : IUseCase<IPresenter<BMIView>, IRepository<PersonEntity>> {
        private const int personMaxNameLength = 10;
        private readonly IBMIVewPresenter presenter;
        private readonly IPersonRepository repository;
        private readonly BMIModel model;

        public BMIUseCase(IBMIVewPresenter presenter, IPersonRepository repository) {
            this.presenter = presenter;
            this.repository = repository;
            model = new BMIModel();
        }

        public void Initialize() {
            var person = repository.GetPerson();
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
                    repository.SetPerson(person);
                });
            presenter
                .PersonAgeInput
                .SkipLatestValueOnSubscribe()
                .Subscribe(x => {
                    if (int.TryParse(x, out int age) && age >= 0) {
                        person.Age = age;
                        repository.SetPerson(person);
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
                        person.BMI = model.CalcBMI(person.Height, person.Weight);
                        presenter.SetPersonBMI(person.BMI.ToString("F1"));
                        presenter.SetPersonBMIEvaluation(model.EvaluateBMI(person.BMI).ToJpn());
                        repository.SetPerson(person);
                    } else {
                        presenter.SetPersonHeight(""); // 不正な入力は削除
                        presenter.SetPersonBMI("0.0");
                        presenter.SetPersonBMIEvaluation(BMIEvalType.Unknown.ToJpn());
                    }
                });
            presenter
                .PersonWeightInput
                .SkipLatestValueOnSubscribe()
                .Subscribe(x => {
                    if (float.TryParse(x, out float weight) && weight > 0.0F) {
                        person.Weight = weight;
                        person.BMI = model.CalcBMI(person.Height, person.Weight);
                        presenter.SetPersonBMI(person.BMI.ToString("F1"));
                        presenter.SetPersonBMIEvaluation(model.EvaluateBMI(person.BMI).ToJpn());
                        repository.SetPerson(person);
                    } else {
                        presenter.SetPersonWeight(""); // 不正な入力は削除
                        presenter.SetPersonBMI("0.0");
                        presenter.SetPersonBMIEvaluation(BMIEvalType.Unknown.ToJpn());
                    }
                });
            presenter.Bind();
        }
    }
}
