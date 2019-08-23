using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace BMIApp.BMI {
    public interface IHistoryListPresenter : CleanArchitecture.IPresenter {
        IObservable<Unit> ClearButtonClickObservable { get; }
        void Add(string name, string bmi, string createdAt);
        void ClearList();
    }
}
