using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BMIApp.BMI {
    public enum Gender { None = 0, Male, Female }
    public interface IBMIDataTransferObject : CleanArchitecture.IDataTransferObject {
        string Name { set; get; }
        float Height { set; get; }
        float Weight { set; get; }
        int Age { set; get; }
        Gender Gender { set; get; }
        float BMI { set; get; }
        DateTime CreatedAt { set; get; }
    }
}
