using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BMIApp {
    public interface IUserAccountRepository : CleanArchitecture.IRepository {
        string CurrentUserId { set; get; }
        string CurrentUserToken { set; get; }
        void Clear();
    }
}
