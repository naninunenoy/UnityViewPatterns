﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViewPatterns.MVP {
    public class UseCase : MonoBehaviour {
        [SerializeField] MvpBmiView view = default;

        BMIModel model = default;
        BMIPresenter presenter = default;

        void Awake() {
            model = new BMIModel(new PersonEntity());
            presenter = new BMIPresenter(model);
        }

        void Start() {
            model.Initialize();
            view.Bind(presenter, model);
        }
    }
}
