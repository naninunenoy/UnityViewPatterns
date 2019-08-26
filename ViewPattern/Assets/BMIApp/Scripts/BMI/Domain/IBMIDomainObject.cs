using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BMIApp.BMI {
    public interface IBMIDomainObject : CleanArchitecture.IDomainObject {
        float Height { get; }
        float Weight { get; }
    }
}
