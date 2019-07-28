using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BMIApp.BMI {
    public class BMIView : MonoBehaviour, IBMIView {
        [SerializeField] InputField nameInput = default;
        [SerializeField] InputField heightInput = default;
        [SerializeField] InputField weightInput = default;
        [SerializeField] InputField ageInput = default;
        [SerializeField] Toggle genderMaleToggle = default;
        [SerializeField] Toggle genderFemaleToggle = default;
        [SerializeField] Text bmiText = default;
        [SerializeField] Button saveButton = default;

        public InputField NameInput => nameInput;
        public InputField HeightInput => heightInput;
        public InputField WeightInput => weightInput;
        public InputField AgeInput => ageInput;
        public Toggle GenderMaleToggle => genderMaleToggle;
        public Toggle GenderFemaleToggle => genderFemaleToggle;
        public Text BMIText => bmiText;
        public Button SaveButton => saveButton;
    }
}
