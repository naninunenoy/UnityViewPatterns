using UnityEngine;
using Zenject;

namespace BMIApp.CleanArchitecture {
    public abstract class MainInstallerBase : MonoInstaller, IMainInstaller {
        [SerializeField] GameObject main = default;
        public GameObject SceneMainObject => main;

        public override void InstallBindings() {
            // Bind�̓��e�Ńe�X�g�ɂ����s���𔻒f���A
            // �e�X�g�̏ꍇ��main�������Ŕ񊈐������A
            // �e�X�g����C�ӂ̃^�C�~���O��Awake���Ăׂ�悤�ɂ���
            if (Container.HasBinding<ITest>()) {
                main.SetActive(false);
            }
        }
    }
}
