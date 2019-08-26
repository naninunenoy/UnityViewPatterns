using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BMIApp.BMI {
    public interface IPushHistoryDelegate {
        void OnPushBMIData(IBMIDataTransferObject data);
    }
}
