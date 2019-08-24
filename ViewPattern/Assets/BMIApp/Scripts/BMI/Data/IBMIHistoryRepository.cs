using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace BMIApp.BMI {
    public interface IBMIHistoryRepository : CleanArchitecture.IRepository {
        Task SaveAsync(IBMIEntity data);
        Task<IEnumerable<IBMIEntity>> LoadAllAsync();
        Task DeleteAllAsync();
    }
}
