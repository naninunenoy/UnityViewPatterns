using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace BMIApp.BMI {
    public class HistoryUseCase<TEntity> : CleanArchitecture.IUseCase , IPushHistoryDelegate where TEntity : IBMIEntity {
        readonly IHistoryListPresenter historyPresenter;
        readonly IBMIHistoryRepository<TEntity> historyRepository;
        readonly Component disposableComponent;

        public HistoryUseCase(IHistoryListPresenter historyPresenter, 
                              IBMIHistoryRepository<TEntity> historyRepository,
                              Component disposableComponent) {
            this.historyPresenter = historyPresenter;
            this.historyRepository = historyRepository;
            this.disposableComponent = disposableComponent;
        }

        public void Begin() {
            // 履歴を全て追加
            historyRepository.LoadAllAsync().ContinueWith(t => {
                foreach (var entity in t.Result) {
                    PushBMIEntity(entity);
                }
            });
            // 履歴削除
            historyPresenter
                .ClearButtonClickObservable
                .Subscribe(async _ => {
                    await historyRepository.DeleteAllAsync();
                    historyPresenter.ClearList();
                })
                .AddTo(disposableComponent);
        }

        public void OnPushBMIEntity(IBMIEntity entity) {
            PushBMIEntity(entity);
        }

        void PushBMIEntity(IBMIEntity entity) {
            historyPresenter.Add(entity.Name, entity.BMI.ToString("F1"), entity.CreatedAt.ToString("MM/dd"));
        }
    }
}
