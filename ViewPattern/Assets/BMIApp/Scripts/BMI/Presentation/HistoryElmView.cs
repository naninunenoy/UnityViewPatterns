using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BMIApp.BMI {
    public class HistoryElmView : MonoBehaviour, IHistoryElmView {
        [SerializeField] Text dateText = default;
        [SerializeField] Text nameText = default;
        [SerializeField] Text bmiText = default;

        public Text DateText => dateText;
        public Text NameText => nameText;
        public Text BMIText => bmiText;

        public IHistoryElmView Clone(Transform parent) {
            return Instantiate(gameObject, parent).GetComponent<IHistoryElmView>();
        }
    }
}
