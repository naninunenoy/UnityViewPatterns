using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BMIApp.BMI {
    public class HistoryView : MonoBehaviour, IHistoryView {
        [SerializeField] Button clearButton = default;
        [SerializeField] Transform content = default;

        public Button ClearButton => clearButton;
        public Transform Content => content;
    }
}
