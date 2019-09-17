using UnityEngine;

namespace Player {
    public class Mover : MonoBehaviour {
        [SerializeField]
        private float jumpPower = 5f;

        [SerializeField]
        private float defaultMoveSpeed = 10f;

        private CharacterController characterController;

        private IInputProvider inputProvider;

        private Vector3 moveDirection;

        public void SetInputProvider(IInputProvider input) {
            inputProvider = input;
        }

        void Start() {
            characterController = GetComponent<CharacterController>();
        }

        void Update() {
            moveDirection = Vector3.zero;

            if (inputProvider == null) return;

            if (inputProvider.GetJump()) {
                Jump();
            }

            var inputVector = inputProvider.GetMoveDirection();
            var isDash = inputProvider.GetDash();

            //移動
            Move(inputVector, isDash);

            //重力加速度
            moveDirection = new Vector3(
                moveDirection.x,
                moveDirection.y + Physics.gravity.y * Time.deltaTime + characterController.velocity.y,
                moveDirection.z);

            //移動
            characterController.Move(moveDirection * Time.deltaTime);
        }

        /// <summary>
        /// ジャンプする
        /// </summary>
        void Jump() {
            if (!characterController.isGrounded) return;
            moveDirection = new Vector3(moveDirection.x, moveDirection.y + jumpPower, moveDirection.z);
        }

        /// <summary>
        /// 移動する
        /// </summary>
        /// <param name="direction">移動方向</param>
        /// <param name="isDash">ダッシュするか</param>
        void Move(Vector3 direction, bool isDash) {
            var speed = isDash ? 3 : 1; //ダッシュすると3倍速い
            moveDirection += (direction * speed * defaultMoveSpeed);
        }
    }
}
