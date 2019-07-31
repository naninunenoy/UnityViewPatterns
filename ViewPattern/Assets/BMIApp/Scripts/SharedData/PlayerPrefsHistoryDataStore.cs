using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using UnityEngine;

namespace BMIApp {
    public class PlayerPrefsHistoryDataStore : IHistoryDataStore<BMIEntity> {
        readonly string key;
        public IList<BMIEntity> datas;
        public IList<BMIEntity> Datas => datas;
        public PlayerPrefsHistoryDataStore(string accountId) {
            this.key = accountId;
        }

        public Task LoadAsync() {
            var json = PlayerPrefs.GetString(key);
            if (string.IsNullOrEmpty(json)) {
                datas = new List<BMIEntity>();
                return Task.CompletedTask;
            }
            var arr = JsonUtility.FromJson<BMIEntityArray>(json);
            if (arr == null || arr.Items == null || arr.Items.Count == 0) {
                datas = new List<BMIEntity>();
                return Task.CompletedTask;
            }
            datas = arr.Items.ToList();
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
