﻿using System.Collections;
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
            // initialize view
            presenter.SetPersonName(person.Name);
            presenter.SetPersonAge(person.Age.ToString());
            presenter.SetPersonHeight(person.Height.ToString("F1"));
            presenter.SetPersonWeight(person.Weight.ToString("F1"));
            // observe view update
            presenter.PersonNameInput.Subscribe(x => {
                var name = x;
                if (name.Length > personMaxNameLength) {
                    // 名前は10文字までとする
                    name = string.Concat(name.Take(personMaxNameLength));
                    presenter.SetPersonName(name);
                }
                person.Name = name;
                repository.SetEntity(person);
            });
            presenter.PersonAgeInput.Subscribe(x => {
                if (int.TryParse(x, out int age) && age >= 0) {
                    person.Age = age;
                    repository.SetEntity(person);
                } else {
                    presenter.SetPersonAge(""); // 不正な入力は削除
                }
            });
            presenter.PersonHeightInput.Subscribe(x => {
                if (float.TryParse(x, out float height)) {
                    person.Height = height;
                    repository.SetEntity(person);
                } else {
                    presenter.SetPersonHeight(""); // 不正な入力は削除
                }
            });
            presenter.PersonWeightInput.Subscribe(x => {
                if (float.TryParse(x, out float weight)) {
                    person.Weight = weight;
                    repository.SetEntity(person);
                } else {
                    presenter.SetPersonHeight(""); // 不正な入力は削除
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
