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
            var entities = await historyRepository.LoadAllAsync();
            foreach (var entity in entities) {
                AddToHistory(entity);
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

        public async void OnPushBMIEntity(IBMIDataTransferObject entity) {
            // save
            await historyRepository.SaveAsync(entity);
            AddToHistory(entity);
        }

        void AddToHistory(IBMIDataTransferObject entity) {
            historyPresenter.Add(entity.Name, entity.BMI.ToString("F1"), entity.CreatedAt.ToString("M/d"));
        }
    }
}
