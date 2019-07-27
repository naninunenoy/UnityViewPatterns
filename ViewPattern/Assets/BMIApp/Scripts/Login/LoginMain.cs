using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BMIApp.Login {
    public class LoginMain : MonoBehaviour, CleanArchitecture.ISceneMain {
        [SerializeField] LoginView loginView;
        [SerializeField] AlertView loginAlertView;

        void Awake() {

        }

        // Start is called before the first frame update
        void Start() {

        }
    }
}
