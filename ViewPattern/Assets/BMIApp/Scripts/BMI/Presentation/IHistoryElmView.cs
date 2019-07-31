using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BMIApp.BMI {
    public interface IHistoryElmView : CleanArchitecture.IView {
        Text DateText { get; }
        Text NameText { get; }
        Text BMIText { get; }
        IHistoryElmView Clone(Transform parent);
    }
}
