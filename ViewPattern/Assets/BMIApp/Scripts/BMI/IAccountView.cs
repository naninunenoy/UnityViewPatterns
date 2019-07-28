using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BMIApp.BMI {
    public interface IAccountView : CleanArchitecture.IView {
        Button LogoutButton { get; }
        Text AccountNameText { get; }
    }
}
