using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace BMIApp.BMI {
    public interface IBMIHistoryRepository : CleanArchitecture.IRepository {
        Task SaveAsync(IBMIDataTransferObject data);
        Task<IEnumerable<IBMIDataTransferObject>> LoadAllAsync();
        Task DeleteAllAsync();
    }
}
