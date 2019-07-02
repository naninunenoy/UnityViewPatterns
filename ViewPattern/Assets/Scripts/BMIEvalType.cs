using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViewPatterns {
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
