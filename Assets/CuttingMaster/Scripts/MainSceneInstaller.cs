using UnityEngine;
using Zenject;

public class MainSceneInstaller : MonoInstaller 
{
    [SerializeField] private SpawnerConfig _spawnerConfig;
    [SerializeField] private ThrownObjects _thrownObjects;
    [SerializeField] private ItemSpawner _itemSpawner;

    public override void InstallBindings()
    {
        Container.Bind<ISpawnerConfig>().FromInstance(_spawnerConfig);
        Container.Bind<ThrownObjects>().FromInstance(_thrownObjects);
        Container.Bind<ItemSpawner>().FromInstance(_itemSpawner);
    }
}
