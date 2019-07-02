using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ViewPatterns {
    public class View : MonoBehaviour {
        [SerializeField] InputField nameInputField = default;
        [SerializeField] InputField ageInputField = default;
        [SerializeField] InputField heightInputField = default;
        [SerializeField] InputField weightInputField = default;
        [SerializeField] Text bimText = default;
        InputField NameInputField { get { return nameInputField; } }
        InputField AgeInputField { get { return ageInputField; } }
        InputField HeightInputField { get { return heightInputField; } }
        InputField WeightInputField { get { return weightInputField; } }
        Text BMIText { get { return bimText; } }
    }
}
