using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace BMIApp.BMI {
    public interface IHistoryDataStore : CleanArchitecture.IDataStore {
        IList<IBMIEntity> Datas { get; }
        Task LoadAsync();
        Task SaveAsync();
        Task DeleteAsync();
    }
}
