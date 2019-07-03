using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ViewPatterns {
    public class BMIView : MonoBehaviour, IView {
        [SerializeField] InputField nameInputField = default;
        [SerializeField] InputField ageInputField = default;
        [SerializeField] InputField heightInputField = default;
        [SerializeField] InputField weightInputField = default;
        [SerializeField] Text bimValueText = default;
        [SerializeField] Text bimEvaluateText = default;
        public InputField NameInputField { get { return nameInputField; } }
        public InputField AgeInputField { get { return ageInputField; } }
        public InputField HeightInputField { get { return heightInputField; } }
        public InputField WeightInputField { get { return weightInputField; } }
        public Text BMIValueText { get { return bimValueText; } }
        public Text BMIEvaluateText { get { return bimEvaluateText; } }
    }
}
