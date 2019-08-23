using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace BMIApp.BMI {
    public class HistoryUseCase<TEntity> : CleanArchitecture.IUseCase , IPushHistoryDelegate where TEntity : IBMIEntity, new() {
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
                    AddToHistory(entity);
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
            // copy
            var newEntiry = new TEntity {
                Name = entity.Name,
                Height = entity.Height,
                Weight = entity.Weight,
                Age = entity.Age,
                Gender = entity.Gender,
                BMI = entity.BMI,
                CreatedAt = entity.CreatedAt
            };
            // save
            historyRepository.SaveAsync(newEntiry).ContinueWith(_ => {
                AddToHistory(newEntiry);
            });
        }

        void AddToHistory(IBMIEntity entity) {
            historyPresenter.Add(entity.Name, entity.BMI.ToString("F1"), entity.CreatedAt.ToString("MM/dd"));
        }
    }
}
