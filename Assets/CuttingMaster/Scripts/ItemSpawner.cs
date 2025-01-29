using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class ItemSpawner : MonoBehaviour
{
    private int _spawnDelay;
    private int _boundX;
    private Vector3 _forceToThrow;
    private ThrownObjects _thrownObjects;
    private Coroutine _spawning;

    [Inject]
    public void Init(ISpawnerConfig spawnerConfig, ThrownObjects thrownObjects)
    {
        transform.position = spawnerConfig.Position;
        _spawnDelay = spawnerConfig.SpawnDelay;
        _boundX = spawnerConfig.BoundX;
        _forceToThrow = spawnerConfig.ForceToThrow;
        _thrownObjects = thrownObjects;
    }

    public void StartSpawning()
    {
        _spawning = StartCoroutine(Spawning());
    }

    public void StopSpawning()
    {
        StopCoroutine(_spawning);
    }

    private IEnumerator Spawning()
    {
        while (true)
        {
            ThrownObject thrownObject = _thrownObjects.GetRandomThrownObj();
            Vector3 posToSpawn = transform.position + new Vector3(Random.Range(-_boundX, _boundX), 0, 0);

            Object objOfThrownObject = Instantiate(thrownObject, posToSpawn, thrownObject.transform.rotation);

            objOfThrownObject.GetComponent<Rigidbody>().AddForce(_forceToThrow);

            yield return new WaitForSeconds(_spawnDelay);
        }
    }

}
