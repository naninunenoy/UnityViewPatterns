using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace BMIApp.BMI {
    public interface IHistoryDataStore<T> : CleanArchitecture.IDataStore where T : IBMIEntity {
        IList<T> Datas { get; }
        Task LoadAsync();
        Task SaveAsync();
        Task DeleteAsync();
    }
}
