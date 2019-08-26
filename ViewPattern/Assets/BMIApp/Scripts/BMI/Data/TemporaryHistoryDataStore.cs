using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace BMIApp.BMI {
    public class TemporaryHistoryDataStore : IHistoryDataStore {
        public IList<IBMIDataTransferObject> Datas { private set; get; }

        public TemporaryHistoryDataStore() {
            Datas = new List<IBMIDataTransferObject>();
        }

        public Task DeleteAsync() {
            Datas.Clear();
            return Task.CompletedTask;
        }

        public Task LoadAsync() {
            // Do Nothing
            return Task.CompletedTask;
        }

        public Task SaveAsync() {
            // Do Nothing
            return Task.CompletedTask;
        }
    }
}
