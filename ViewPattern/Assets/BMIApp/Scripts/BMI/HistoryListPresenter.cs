using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BMIApp.BMI {
    public class HistoryListPresenter : IHistoryListPresenter {
        readonly IHistoryView view;
        readonly IHistoryElmView elm;

        public HistoryListPresenter(IHistoryView view, IHistoryElmView elm) {
            this.view = view;
            this.elm = elm;
        }

        public void Add(string name, string bmi, string createdAt) {
            var newElm = elm.Clone(view.Content);
            newElm.NameText.text = name;
            newElm.BMIText.text = bmi;
            newElm.DateText.text = createdAt;
        }

        public void ClearList() {
            for (int i = 0; i < view.Content.childCount; i++) {
                GameObject.Destroy(view.Content.GetChild(i).gameObject);
            }
        }
    }
}
