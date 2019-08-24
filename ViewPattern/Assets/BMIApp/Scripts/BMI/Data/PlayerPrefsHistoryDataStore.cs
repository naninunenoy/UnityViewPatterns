using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using UnityEngine;

namespace BMIApp.BMI {
    public class PlayerPrefsHistoryDataStore : IHistoryDataStore {
        readonly string key;
        public IList<IBMIEntity> datas;
        public IList<IBMIEntity> Datas => datas;
        public PlayerPrefsHistoryDataStore(string accountId) {
            this.key = accountId;
        }

        public Task LoadAsync() {
            var json = PlayerPrefs.GetString(key);
            if (string.IsNullOrEmpty(json)) {
                datas = new List<IBMIEntity>();
                return Task.CompletedTask;
            }
            var arr = JsonUtility.FromJson<BMIEntityArray>(json);
            if (arr?.Items == null || arr.Items.Count == 0) {
                datas = new List<IBMIEntity>();
                return Task.CompletedTask;
            }
            datas = arr.Items.Cast<IBMIEntity>().ToList();
            return Task.CompletedTask;
        }

        public Task SaveAsync() {
            var arr = new BMIEntityArray(datas.ToArray());
            var json = JsonUtility.ToJson(arr) ?? "{}";
            PlayerPrefs.SetString(key, json);
            return Task.CompletedTask;
        }

        public Task DeleteAsync() {
            PlayerPrefs.DeleteKey(key);
            return Task.CompletedTask;
        }
    }
}
