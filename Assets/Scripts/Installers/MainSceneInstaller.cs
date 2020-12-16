using Common;
using Services.Configs;
using Services.PlayerData;
using Zenject;

namespace Installers
{
    public class MainSceneInstaller : MonoInstaller<MainSceneInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<FooMonoBehaviour>().FromNewComponentOnNewGameObject().WithGameObjectName("FooGameObject").AsSingle();

            Container.Bind<IConfigsLoadingService>().To<URLConfigsLoadingService>().AsSingle();
            Container.Bind<IPlayerDataLoadingService>().To<PlayerPrefsPlayerDataLoadingService>().AsSingle();
            Container.Bind<IPlayerDataSavingService>().To<PlayerPrefsPlayerDataSavingService>().AsSingle();

            Container.BindInterfacesAndSelfTo<ConfigsService>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerDataService>().AsSingle();
        }
    }
}
