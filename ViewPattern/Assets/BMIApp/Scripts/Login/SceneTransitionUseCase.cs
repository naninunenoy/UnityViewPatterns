using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BMIApp.Login {
    public class SceneTransitionUseCase : CleanArchitecture.IUseCase, IAuthResultDelegate {
        void IAuthResultDelegate.OnAuthFailure() {
            // Do Nothing
        }

        void IAuthResultDelegate.OnAuthSuccess() {
            SceneManager.LoadScene("BMI");
        }
        public void Begin() {
            // Do Nothing
        }
    }
}
