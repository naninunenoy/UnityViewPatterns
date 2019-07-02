using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViewPatterns {
    public class BMICalculateModel : IModel<PersonEntity, float> {
        public bool TryApply(PersonEntity data, out float result) {
            result = 0.0F;
            if (data == null) {
                return false;
            }
            if (Mathf.Approximately(0.0F, data.Height)) {
                return false;
            }
            // BIM = 体重[kg] / 身長[m]^2
            var merter = data.Height / 100.0F;
            result = data.Weight / (merter * merter);
            return true;
        }
    }
}
