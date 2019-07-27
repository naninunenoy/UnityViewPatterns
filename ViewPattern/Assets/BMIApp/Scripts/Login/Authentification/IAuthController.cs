using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace BMIApp.Login {
    public interface IAuthController : CleanArchitecture.IController {
        Task<string> TryGetTokenAsync(string id, string password);
    }
}
