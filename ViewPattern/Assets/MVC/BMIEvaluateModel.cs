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
            } else if (25.0 <= data && data < 30.0F)  {
                result = BMIEvalType.Overweight;
            } else  /* if (data <= 30.0F) */ {
                result = BMIEvalType.Moderately;
            }
            return true;
        }
    }

    public enum BMIEvalType {
        Unknown = 0,
        VerySeverelyUnderweight,
        SeverelyUnderweight,
        Underweight,
        Normal,
        Overweight,
        Moderately
    }

    public static class BMIEvalTypeEx {
        public static string ToJpn(this BMIEvalType type) {
            switch (type) {
            case BMIEvalType.VerySeverelyUnderweight:
                return "超痩せすぎ";
            case BMIEvalType.SeverelyUnderweight:
                return "痩せ過ぎ";
            case BMIEvalType.Underweight:
                return "痩せ型";
            case BMIEvalType.Normal:
                return "標準";
            case BMIEvalType.Overweight:
                return "肥満気味";
            case BMIEvalType.Moderately:
                return "肥満";
            case BMIEvalType.Unknown:
            default:
                return "不明";
            }
        }
    }
}
