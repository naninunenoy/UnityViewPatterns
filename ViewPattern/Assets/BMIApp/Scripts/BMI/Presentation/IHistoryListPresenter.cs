using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BMIApp.BMI {
    public interface IHistoryListPresenter : CleanArchitecture.IPresenter {
        void Add(string name, string bmi, string createdAt);
        void ClearList();
    }
}
