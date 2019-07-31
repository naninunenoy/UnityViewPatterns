using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BMIApp.BMI {
    public interface IBMIView : CleanArchitecture.IView {
        InputField NameInput { get; }
        InputField HeightInput { get; }
        InputField WeightInput { get; }
        InputField AgeInput { get; }
        Toggle GenderMaleToggle { get; }
        Toggle GenderFemaleToggle { get; }
        Text BMIText { get; }
        Button SaveButton { get; }
    }
}
