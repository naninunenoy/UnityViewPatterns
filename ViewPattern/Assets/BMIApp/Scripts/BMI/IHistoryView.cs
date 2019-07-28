using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BMIApp.BMI {
    public interface IHistoryView : CleanArchitecture.IView {
        Button ClearButton { get; }
        Transform Content { get; }
    }
}
