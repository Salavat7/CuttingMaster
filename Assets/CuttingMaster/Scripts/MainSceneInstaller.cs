using UnityEngine;
using Zenject;

public class MainSceneInstaller : MonoInstaller 
{
    [SerializeField] private SpawnerConfig _spawnerConfig;
    [SerializeField] private ThrownObjects _thrownObjects;
    [SerializeField] private ItemSpawner _itemSpawner;
    [SerializeField] private Slicer _slicer;
    [SerializeField] private MainMenuView _mainMenuView;
    [SerializeField] private SettingsView _settingsView;

    public override void InstallBindings()
    {
        Container.Bind<ISpawnerConfig>().FromInstance(_spawnerConfig);
        Container.Bind<ThrownObjects>().FromInstance(_thrownObjects);
        Container.Bind<ItemSpawner>().FromInstance(_itemSpawner);
        Container.Bind<Slicer>().FromInstance(_slicer);
        Container.Bind<MainMenuView>().FromInstance(_mainMenuView);
        Container.Bind<SettingsView>().FromInstance(_settingsView);
        Container.BindInterfacesAndSelfTo<MainMenuViewMediator>().FromNew().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<SettingsViewMediator>().FromNew().AsSingle().NonLazy();
    }

}
