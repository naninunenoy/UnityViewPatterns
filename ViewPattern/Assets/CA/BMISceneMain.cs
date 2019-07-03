using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViewPatterns.CA {
    public class BMISceneMain : MonoBehaviour, ISceneMain {
        [SerializeField] BMIView bmiView = default;

        IUseCase<BMIPresenter, PersonRepository> bmiUseCase = default;

        void Awake() {
            var bmiPresenter = new BMIPresenter();
            var personRepository = new PersonRepository();
            bmiUseCase = new BMIUseCase(bmiPresenter, personRepository);
        }
    }
}
