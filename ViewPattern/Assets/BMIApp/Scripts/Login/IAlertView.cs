using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BMIApp.Login {
    public interface IAlertView : CleanArchitecture.IView {
        Button CloseButton { get; }
        Text AlertText { get; }
        Transform ViewTransform { get; }
    }
}
