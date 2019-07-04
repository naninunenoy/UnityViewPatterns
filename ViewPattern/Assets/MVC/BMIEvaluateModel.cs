using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViewPatterns.MVC {
    public class BMIEvaluateModel : IModel<float, BMIEvalType> {
        public bool TryApply(float data, out BMIEvalType result) {
            if (data <= 0.0F) {
                result = BMIEvalType.Unknown;
            } else if (/*0.0F <= data &&*/ data < 15.0F) {
                result = BMIEvalType.VerySeverelyUnderweight;
            } else if (15.0 <= data && data < 16.0F) {
                result = BMIEvalType.SeverelyUnderweight;
            } else if (16.0 <= data && data < 18.5F) {
                result = BMIEvalType.Underweight;
            } else if (18.5 <= data && data < 25.0F) {
                result = BMIEvalType.Normal;
            } else if (25.0 <= data && data < 30.0F) {
                result = BMIEvalType.Overweight;
            } else  /* if (data <= 30.0F) */ {
                result = BMIEvalType.Obese;
            }
            return true;
        }
    }
}
