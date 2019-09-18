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
            // ユーザ未設定でこのシーンを開いた場合、debug用のrepositoryを参照
            var dataStore = string.IsNullOrEmpty(sharedData.CurrentUserId) ?
                new TemporaryHistoryDataStore() as IHistoryDataStore :
                new PlayerPrefsHistoryDataStore(sharedData.CurrentUserId) as IHistoryDataStore;
            Container
                .Bind<IHistoryListPresenter>()
                .FromInstance(new HistoryListPresenter(historyView, historyElmView))
                .AsCached()
                .IfNotBound();
            Container
                .Bind<IBMIHistoryRepository>()
                .FromInstance(new BMIHistoryRepository(dataStore))
                .AsCached()
                .IfNotBound();
            Container
                .Bind<IBMIPresenter>()
                .FromInstance(new BMIPresenter(bmiView))
                .AsCached()
                .IfNotBound();
            Container
                .Bind<IUserAccountRepository>()
                .FromInstance(new UserAccountRepository(sharedData))
                .AsCached()
                .IfNotBound();
            Container
                .Bind<IAccountPresenter>()
                .FromInstance(new AccountPresenter(accountView))
                .AsCached()
                .IfNotBound();
        }
    }
}
