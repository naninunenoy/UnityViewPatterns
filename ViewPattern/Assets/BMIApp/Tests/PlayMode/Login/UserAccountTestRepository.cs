using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BMIApp.Tests.PlayMode {
    public class UserAccountTestRepository : IUserAccountRepository {
        public UserAccountRepository InnerRepository { set; get; }
        public string CurrentUserId { set => InnerRepository.CurrentUserId = value; get => InnerRepository.CurrentUserId; }
        public string CurrentUserToken { set => InnerRepository.CurrentUserToken = value;  get => InnerRepository.CurrentUserToken; }
        public void Clear() => InnerRepository?.Clear();
    }
}
