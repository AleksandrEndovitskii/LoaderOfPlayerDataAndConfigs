using Services.Configs;
using Services.PlayerData;
using Zenject;

namespace Installers
{
    public class MainSceneInstaller : MonoInstaller<MainSceneInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ConfigsLoadingService>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerDataLoadingService>().AsSingle();

            Container.BindInterfacesAndSelfTo<ConfigsService>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerDataService>().AsSingle();
        }
    }
}
