using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using BMIApp.BMI;

namespace BMIApp.Tests.PlayMode {
    public class HistoryListTestPresenter : IHistoryListPresenter {
        public HistoryListPresenter InnerPresenter { set; get; }

        public IObservable<Unit> ClearButtonClickObservable => InnerPresenter.ClearButtonClickObservable;

        public void Add(string name, string bmi, string createdAt) {
            InnerPresenter.Add(name, bmi, createdAt);
        }

        public void ClearList() {
            InnerPresenter.ClearList();
        }
    }
}
