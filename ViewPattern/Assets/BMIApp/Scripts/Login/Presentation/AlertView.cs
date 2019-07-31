using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BMIApp.Login {
    public class AlertView : MonoBehaviour, IAlertView {
        [SerializeField] Text alertText = default;
        [SerializeField] Button closeButton = default;

        public Text AlertText => alertText;
        public Button CloseButton => closeButton;
        public Transform ViewTransform { get => transform; }
    }
}
