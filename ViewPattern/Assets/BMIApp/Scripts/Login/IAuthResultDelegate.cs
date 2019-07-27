using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BMIApp.Login {
    public interface IAuthResultDelegate {
        void OnAuthSuccess();
        void OnAuthFailure();
    }
}
