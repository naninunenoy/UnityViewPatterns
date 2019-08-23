using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace BMIApp {
    public interface IBMIHistoryRepository<T> : CleanArchitecture.IRepository where T : IBMIEntity {
        Task SaveAsync(T data);
        Task<IEnumerable<T>> LoadAllAsync();
        Task DeleteAllAsync();
    }
}
