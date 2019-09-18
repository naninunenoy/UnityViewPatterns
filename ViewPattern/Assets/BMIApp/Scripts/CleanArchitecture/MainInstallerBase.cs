using UnityEngine;
using Zenject;

namespace BMIApp.CleanArchitecture {
    public abstract class MainInstallerBase : MonoInstaller, IMainInstaller {
        [SerializeField] GameObject main = default;
        public GameObject SceneMainObject => main;

        public override void InstallBindings() {
            // Bindの内容でテストによる実行かを判断し、
            // テストの場合はmainをここで非活性化し、
            // テストから任意のタイミングでAwakeを呼べるようにする
            if (Container.HasBinding<ITest>()) {
                main.SetActive(false);
            }
        }
    }
}
