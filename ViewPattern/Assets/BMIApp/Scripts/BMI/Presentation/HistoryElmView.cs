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
            var newObj = Instantiate(gameObject, parent);
            // contentの一番上に新要素を追加するようにする
            newObj.transform.SetSiblingIndex(0);
            return newObj.GetComponent<IHistoryElmView>();
        }
    }
}
