using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace ViewPatterns.CA {
    public interface IBMIVewPresenter : Core.IPresenter {
        // view property changed
        IReadOnlyReactiveProperty<string> PersonNameInput { get; }
        IReadOnlyReactiveProperty<string> PersonAgeInput { get; }
        IReadOnlyReactiveProperty<string> PersonHeightInput { get; }
        IReadOnlyReactiveProperty<string> PersonWeightInput { get; }
        // overwrite view property
        void SetPersonName(string name);
        void SetPersonAge(string age);
        void SetPersonHeight(string height);
        void SetPersonWeight(string weight);
        void SetPersonBMI(string bmi);
        void SetPersonBMIEvaluation(string eval);
        // listen view events
        void Bind();
    }
}
