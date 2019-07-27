using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BMIApp.Login {
    public interface ILoginView : CleanArchitecture.IView {
        InputField IdInputField { get; }
        InputField PasswordInputField { get; }
        Button LoginButton { get; }
    }
}
