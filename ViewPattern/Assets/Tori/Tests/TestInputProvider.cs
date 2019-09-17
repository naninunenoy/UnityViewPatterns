using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player {
    // それっぽく実装
    public class TestInputProvider : IInputProvider {
        public bool IsDash { set; get; }
        public bool IsJump { set; get; }
        public Vector3 MoveDirection { set; get; }

        public bool GetDash() {
            return IsDash;
        }

        public bool GetJump() {
            return IsJump;
        }

        public Vector3 GetMoveDirection() {
            return MoveDirection;
        }

        public void Reset() {
            IsDash = false;
            IsJump = false;
            MoveDirection = Vector3.zero;
        }
    }
}
