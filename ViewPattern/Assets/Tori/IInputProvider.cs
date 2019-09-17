using UnityEngine;

namespace Player {
    public interface IInputProvider {
        bool GetDash();
        bool GetJump();
        Vector3 GetMoveDirection();
    }
}
