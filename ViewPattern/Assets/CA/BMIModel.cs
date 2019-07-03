using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViewPatterns.CA {
    public class BMIModel : IModel {
        public const float invalidBMI = float.MaxValue;

        public float CalcBMI(float height, float weight) {
            var h = height / 100.0F; // cm -> m
            return Mathf.Approximately(h, 0.0F) ? invalidBMI : weight / (h * h);
        }

        public BMIEvalType EvaluateBMI(float bmi) {
            if (bmi <= 0.0F) {
                return BMIEvalType.Unknown;
            } else if (/*0.0F <= bmi &&*/ bmi < 15.0F) {
                return BMIEvalType.VerySeverelyUnderweight;
            } else if (15.0 <= bmi && bmi < 16.0F) {
                return BMIEvalType.SeverelyUnderweight;
            } else if (16.0 <= bmi && bmi < 18.5F) {
                return BMIEvalType.Underweight;
            } else if (18.5 <= bmi && bmi < 25.0F) {
                return BMIEvalType.Normal;
            } else if (25.0 <= bmi && bmi < 30.0F) {
                return BMIEvalType.Overweight;
            } else  /* if (bmi <= 30.0F) */ {
                return BMIEvalType.Moderately;
            }
        }
    }
}
