﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ViewPatterns.MVC {
    public class Controller : MonoBehaviour {
        const int maxNameLength = 10;

        [SerializeField] BMIView bmiView = default;
        BMICalculateModel bmiCalcModel = default;
        BMIEvaluateModel bmiEvalModel = default;
        PersonEntity person = default;

        void Awake() {
            person = new PersonEntity();
            bmiCalcModel = new BMICalculateModel();
            bmiEvalModel = new BMIEvaluateModel();
        }

        void Start() {
            // 初期データで計算
            CalcPersonBMI();
        }

        public void SetPersonName(string personName) {
            if (string.IsNullOrEmpty(personName)) {
                return;
            }
            if (personName.Length >= maxNameLength) {
                // 10文字以内に抑える
                bmiView.NameInputField.text = string.Concat(personName.Take(maxNameLength));
                return;
            }
            person.Name = personName;
        }

        public void SetPersonAge(string personAgeStr) {
            if (string.IsNullOrEmpty(personAgeStr)) {
                return;
            }
            if (int.TryParse(personAgeStr, out int age)  && age >= 0) {
                person.Age = age;
            } else {
                bmiView.AgeInputField.text = ""; // 不正入力は消す
            }
        }

        public void SetPersonHeight(string personHeightStr) {
            if (string.IsNullOrEmpty(personHeightStr)) {
                return;
            }
            if (float.TryParse(personHeightStr, out float height) && height > 0.0F) {
                person.Height = height;
                // 身長更新のためBMIを更新
                CalcPersonBMI();
            } else {
                bmiView.HeightInputField.text = ""; // 不正入力は消す
            }
        }

        public void SetPersonWeight(string personWeightStr) {
            if (string.IsNullOrEmpty(personWeightStr)) {
                return;
            }
            if (float.TryParse(personWeightStr, out float weight) && weight > 0.0F) {
                person.Weight = weight;
                // 身長更新のためBMIを更新
                CalcPersonBMI();
            } else {
                bmiView.WeightInputField.text = ""; // 不正入力は消す
            }
        }

        void CalcPersonBMI() {
            // BMIを計算
            if (bmiCalcModel.TryApply(person, out float bmi)) {
                bmiView.BMIValueText.text = bmi.ToString("F1");
            } else {
                bmiView.BMIValueText.text = "?";
            }
            // BMIを評価
            if (bmiEvalModel.TryApply(bmi, out BMIEvalType bmiResult)) {
                bmiView.BMIEvaluateText.text = $"{bmiResult.ToJpn()}です";
            } else {
                bmiView.BMIEvaluateText.text = "???";
            }
        }
    }
}
