using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace BMIApp.BMI {
    public class BMIHistoryRepository : IBMIHistoryRepository {
        readonly IHistoryDataStore dataStore;

        public BMIHistoryRepository(IHistoryDataStore dataStore) {
            this.dataStore = dataStore;
        }

        public async Task<IEnumerable<IBMIEntity>> LoadAllAsync() {
            await dataStore.LoadAsync();
            return dataStore.Datas;
        }

        public async Task SaveAsync(IBMIEntity data) {
            dataStore.Datas.Add(data);
            await dataStore.SaveAsync();
        }

        public async Task DeleteAllAsync() {
            await dataStore.DeleteAsync();
        }
    }
}
