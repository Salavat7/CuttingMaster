using UnityEngine;
using Zenject;

public class MainSceneInstaller : MonoInstaller 
{
    [SerializeField] private SpawnerConfig _spawnerConfig;
    [SerializeField] private ThrownObjects _thrownObjects;

    public override void InstallBindings()
    {
        Container.Bind<ItemSpawner>().FromMethod(GetItemSpawner).NonLazy();
    }

    private ItemSpawner GetItemSpawner()
    {
        GameObject gameObject = new GameObject("Item spawner");
        ItemSpawner itemSpawner = gameObject.AddComponent<ItemSpawner>();
        itemSpawner.Init(_spawnerConfig, _thrownObjects);
        itemSpawner.StartSpawning();

        return itemSpawner;
    }
}
