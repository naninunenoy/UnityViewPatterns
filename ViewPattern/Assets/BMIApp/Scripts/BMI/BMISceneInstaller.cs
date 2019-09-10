using UnityEngine;
using Zenject;

namespace BMIApp.BMI {
    public class BMISceneInstaller : MonoInstaller {
        [SerializeField] SharedScriptableObject sharedData = default;
        [SerializeField] BMIView bmiView = default;
        [SerializeField] HistoryView historyView = default;
        [SerializeField] HistoryElmView historyElmView = default;
        [SerializeField] AccountView accountView = default;

        public override void InstallBindings() {
            // ���[�U���ݒ�ł��̃V�[�����J�����ꍇ�Adebug�p��repository���Q��
            var dataStore = string.IsNullOrEmpty(sharedData.CurrentUserId) ?
                new TemporaryHistoryDataStore() as IHistoryDataStore :
                new PlayerPrefsHistoryDataStore(sharedData.CurrentUserId) as IHistoryDataStore;
            Container
                .Bind<IHistoryListPresenter>()
                .FromInstance(new HistoryListPresenter(historyView, historyElmView))
                .AsCached();
            Container
                .Bind<IBMIHistoryRepository>()
                .FromInstance(new BMIHistoryRepository(dataStore))
                .AsCached();
            Container
                .Bind<IBMIPresenter>()
                .FromInstance(new BMIPresenter(bmiView))
                .AsCached();
            Container
                .Bind<IUserAccountRepository>()
                .FromInstance(new UserAccountRepository(sharedData))
                .AsCached();
            Container
                .Bind<IAccountPresenter>()
                .FromInstance(new AccountPresenter(accountView))
                .AsCached();
        }
    }
}
