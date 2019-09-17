using InputProviders;
using Player;
using Zenject;

namespace ZenjectSample {
    public class UnityInputInstaller : MonoInstaller<UnityInputInstaller> {
        public override void InstallBindings() {
            Container
                .Bind<IInputProvider>()   // IInputProviderが要求されたら
                .To<UnityInputProvider>() // UnityInputProviderを生成して注入する
                .AsCached();              // ただし、UnityInputProviderが生成済みなら使い回す
        }
    }
}
