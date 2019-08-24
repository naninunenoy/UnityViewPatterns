using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace BMIApp.BMI {
    public class BMIHistoryRepository : IBMIHistoryRepository<BMIEntity> {
        readonly IHistoryDataStore<BMIEntity> dataStore;

        public BMIHistoryRepository(IHistoryDataStore<BMIEntity> dataStore) {
            this.dataStore = dataStore;
        }

        public async Task<IEnumerable<BMIEntity>> LoadAllAsync() {
            await dataStore.LoadAsync();
            return dataStore.Datas;
        }

        public async Task SaveAsync(BMIEntity data) {
            dataStore.Datas.Add(data);
            await dataStore.SaveAsync();
        }

        public async Task DeleteAllAsync() {
            await dataStore.DeleteAsync();
        }
    }
}
