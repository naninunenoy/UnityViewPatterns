﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace BMIApp.BMI {
    public interface IHistoryDataStore : CleanArchitecture.IDataStore {
        IList<IBMIDataTransferObject> Datas { get; }
        Task LoadAsync();
        Task SaveAsync();
        Task DeleteAsync();
    }
}
