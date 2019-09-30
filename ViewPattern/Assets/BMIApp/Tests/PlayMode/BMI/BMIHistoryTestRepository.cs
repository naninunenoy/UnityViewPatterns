using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using BMIApp.BMI;

namespace BMIApp.Tests.PlayMode {
    public class BMIHistoryTestRepository : IBMIHistoryRepository {
        public BMIHistoryRepository InnerRepository { set; get; }

        public Task DeleteAllAsync() {
            return InnerRepository.DeleteAllAsync();
        }

        public Task<IEnumerable<IBMIDataTransferObject>> LoadAllAsync() {
            return InnerRepository.LoadAllAsync();
        }

        public Task SaveAsync(IBMIDataTransferObject data) {
            return InnerRepository.SaveAsync(data);
        }
    }
}
