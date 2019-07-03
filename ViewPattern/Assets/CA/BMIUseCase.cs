using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViewPatterns.CA {
    public class BMIUseCase : IUseCase<IPresenter<BMIView>, IRepository<PersonEntity>> {
        private readonly BMIPresenter presenter;
        private readonly PersonRepository repository;

        public BMIUseCase(BMIPresenter presenter, PersonRepository repository) {
            this.presenter = presenter;
            this.repository = repository;
        }

        public void Initialize() {
            var person = repository.GetEntity();
            // initialize view
            presenter.SetPersonName(person.Name);
            presenter.SetPersonAge(person.Age.ToString());
            presenter.SetPersonHeight(person.Height.ToString("F1"));
            presenter.SetPersonWeight(person.Weight.ToString("F1"));
            presenter.Bind();
        }
    }
}
