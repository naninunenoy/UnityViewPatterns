using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewPatterns.CA.Core;

namespace ViewPatterns.CA {
    public class BMISceneMain : MonoBehaviour, ISceneMain {
        [SerializeField] BMIView bmiView = default;

        IPresenter bmiPresenter = default;
        IRepository personRepository = default;
        IUseCase bmiUseCase = default;

        void Awake() {
            var presenter = new BMIPresenter(bmiView);
            var repository = new PersonRepository();
            bmiUseCase = new BMIUseCase(presenter, repository);
            bmiPresenter = presenter;
            personRepository = repository;
        }

        void Start() {
            bmiUseCase.Begin();
        }
    }
}
