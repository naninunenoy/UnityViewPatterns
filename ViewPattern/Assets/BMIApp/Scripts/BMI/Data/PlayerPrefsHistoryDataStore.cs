using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using UnityEngine;

namespace BMIApp.BMI {
    public class PlayerPrefsHistoryDataStore : IHistoryDataStore {
        readonly string key;
        public IList<IBMIEntity> Datas { private set; get; }
        public PlayerPrefsHistoryDataStore(string accountId) {
            key = accountId;
        }

        public Task LoadAsync() {
            var json = PlayerPrefs.GetString(key);
            if (string.IsNullOrEmpty(json)) {
                Datas = new List<IBMIEntity>();
                return Task.CompletedTask;
            }
            var arr = JsonUtility.FromJson<BMIEntityArray>(json);
            if (arr?.Items == null || arr.Items.Count == 0) {
                Datas = new List<IBMIEntity>();
                return Task.CompletedTask;
            }
            Datas = arr.Items.Cast<IBMIEntity>().ToList();
            return Task.CompletedTask;
        }

        public Task SaveAsync() {
            var arr = new BMIEntityArray(Datas.ToArray());
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
