using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using BMIApp.BMI;

namespace BMIApp.Tests.PlayMode {
    public class BMIHistoryTestRepository : IBMIHistoryRepository {
        public BMIHistoryRepository InnerRepository { set; get; }
        public Task DeleteAllAsync() => InnerRepository.DeleteAllAsync();
        public Task<IEnumerable<IBMIDataTransferObject>> LoadAllAsync() => InnerRepository.LoadAllAsync();
        public Task SaveAsync(IBMIDataTransferObject data) => InnerRepository.SaveAsync(data);
    }
}
