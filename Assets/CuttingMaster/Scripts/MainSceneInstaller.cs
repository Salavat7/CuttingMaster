using System.Collections;
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

    // private void OnEnable()
    // {
    //     StartCoroutine(Starter());
    // }

    // private IEnumerator Starter()
    // {
    //     yield return new WaitForSeconds(2);
    //     _itemSpawner.StartSpawning();
    // }
}
