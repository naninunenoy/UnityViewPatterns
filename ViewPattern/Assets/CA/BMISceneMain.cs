using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViewPatterns.CA {
    public class BMISceneMain : MonoBehaviour, ISceneMain {
        [SerializeField] BMIView bmiView = default;

        IPresenter<BMIView> bmiPresenter = default;
        IRepository<PersonEntity> personRepository = default;
        IUseCase<IPresenter<BMIView>, IRepository<PersonEntity>> bmiUseCase = default;

        void Awake() {
            var presenter = new BMIPresenter(bmiView);
            var repository = new PersonRepository();
            bmiUseCase = new BMIUseCase(presenter, repository);
            bmiPresenter = presenter;
            personRepository = repository;
        }
    }
}
