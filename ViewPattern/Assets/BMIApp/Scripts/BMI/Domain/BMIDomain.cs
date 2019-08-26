using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BMIApp.BMI {
    public class BMIDomain : IBMIDomain {
        public float CalcBMI(IBMIDomainObject domainObject) {
            if (domainObject.Height <= 0.0F || domainObject.Weight <= 0.0F) {
                return 0.0F;
            }
            var h = domainObject.Height / 100.0F; // cm -> m
            return domainObject.Weight / (h * h);
        }

        public string EvaluateBMI(IBMIDomainObject domainObject) {
            var bmi = CalcBMI(domainObject);
            if (bmi < 16.0F) {
                return "やせすぎ";
            } else if (bmi < 17.0F) {
                return "やせ";
            } else if (bmi < 18.5F) {
                return "やせ気味";
            } else if (bmi < 25.0F) {
                return "普通";
            } else if (bmi < 30.0F) {
                return "肥満気味";
            } else {
                return "肥満";
            }
        }
    }
}
