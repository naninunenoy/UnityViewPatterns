using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BMIApp.BMI {
    public interface IBMIDomain : CleanArchitecture.IDomain {
        string EvaluateBMI(IBMIDomainObject domainObject);
        float CalcBMI(IBMIDomainObject domainObject);
    }
}
