using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BMIApp.BMI {
    public class HistoryUseCase<TEntity> : CleanArchitecture.IUseCase where TEntity : IBMIEntity {
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

        }
    }
}
