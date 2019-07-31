using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BMIApp {
    public interface ISharedData : CleanArchitecture.IDataStore {
        string CurrentUserId { set; get; }
        string CurrentUserToken { set; get; }
        void Clear();
    }
}
