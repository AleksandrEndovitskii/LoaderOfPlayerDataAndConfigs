using Models;
using Services;
using Services.Configs;
using Zenject;

namespace Installers
{
    public class MainSceneInstaller : MonoInstaller<MainSceneInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TestModel>().AsSingle();

            Container.BindInterfacesAndSelfTo<ConfigsLoadingService>().AsSingle();
        }
    }
}
