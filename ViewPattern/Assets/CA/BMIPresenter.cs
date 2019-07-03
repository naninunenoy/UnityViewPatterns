using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ViewPatterns.CA {
    public class BMIPresenter : IPresenter {
        const int maxNameLength = 10;


        //void IBMIViewUpdateDelegate.OnNameInputChange(string personName) {
        //    if (personName.Length > maxNameLength) {
        //        var trimName = string.Concat(personName.Take(maxNameLength));
        //        Model.PersonName.Value = trimName;
        //    } else {
        //        Model.PersonName.Value = personName;
        //    }
        //}

        //void IBMIViewUpdateDelegate.OnAgeInputChange(string personAge) {
        //    if (int.TryParse(personAge, out int age) && age >= 0) {
        //        Model.PersonAge.Value = age;
        //    }
        //}

        //void IBMIViewUpdateDelegate.OnHeightInputChange(string personHeight) {
        //    if (float.TryParse(personHeight, out float height) && height > 0.0F) {
        //        Model.PersonHeight.Value = height;
        //    }
        //}


        //void IBMIViewUpdateDelegate.OnWeightInputChange(string personWeight) {
        //    if (float.TryParse(personWeight, out float weight) && weight > 0.0F) {
        //        Model.PersonWeight.Value = weight;
        //    }
        //}
    }
}
