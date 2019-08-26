using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace BMIApp.BMI {
    public class HistoryUseCase: CleanArchitecture.IUseCase , IPushHistoryDelegate {
        readonly IHistoryListPresenter historyPresenter;
        readonly IBMIHistoryRepository historyRepository;
        readonly Component disposableComponent;

        public HistoryUseCase(IHistoryListPresenter historyPresenter, 
                              IBMIHistoryRepository historyRepository,
                              Component disposableComponent) {
            this.historyPresenter = historyPresenter;
            this.historyRepository = historyRepository;
            this.disposableComponent = disposableComponent;
        }

        public async void Begin() {
            // 履歴を全て追加
            var datas = await historyRepository.LoadAllAsync();
            foreach (var data in datas) {
                AddToHistory(data);
            }
            // 履歴削除
            historyPresenter
                .ClearButtonClickObservable
                .Subscribe(async _ => {
                    await historyRepository.DeleteAllAsync();
                    historyPresenter.ClearList();
                })
                .AddTo(disposableComponent);
        }

        public async void OnPushBMIData(IBMIDataTransferObject data) {
            // save
            await historyRepository.SaveAsync(data);
            AddToHistory(data);
        }

        void AddToHistory(IBMIDataTransferObject data) {
            historyPresenter.Add(data.Name, data.BMI.ToString("F1"), data.CreatedAt.ToString("M/d"));
        }
    }
}
