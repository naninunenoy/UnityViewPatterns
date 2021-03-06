﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewPatterns.CA.Core;

namespace ViewPatterns.CA {
    public class BMISceneMain : MonoBehaviour, ISceneMain {
        [SerializeField] BMIView bmiView = default;

        IUseCase bmiUseCase = default;

        void Awake() {
            var presenter = new BMIPresenter(bmiView);
            var repository = new PersonRepository();
            bmiUseCase = new BMIUseCase(presenter, repository);
        }

        void Start() {
            bmiUseCase.Begin();
        }
    }
}
