using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViewPatterns.CA {
    public class BMIUseCase : MonoBehaviour, IUseCase {
        //[SerializeField] MvpBmiView view = default;

        BMIModel model = default;
        BMIPresenter presenter = default;

        void Awake() {
            model = new BMIModel(new PersonEntity());
            presenter = new BMIPresenter(model);
        }

        void Start() {
            model.Initialize();
            //view.Bind(presenter, model);
        }
    }
}
