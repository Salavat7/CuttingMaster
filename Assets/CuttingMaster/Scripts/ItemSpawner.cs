using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class ItemSpawner : MonoBehaviour
{
    private int _spawnDelay;
    private int _boundX;
    private float _minForce;
    private float _maxForce;
    private float _torque;
    private ThrownObjects _thrownObjects;
    private Coroutine _spawning;

    [Inject]
    public void Init(ISpawnerConfig spawnerConfig, ThrownObjects thrownObjects)
    {
        _spawnDelay = spawnerConfig.SpawnDelay;
        _boundX = spawnerConfig.BoundX;
        _minForce = spawnerConfig.MinForce;
        _maxForce = spawnerConfig.MaxForce;
        _torque = spawnerConfig.Torque;
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

            Object objOfThrownObject = Instantiate(thrownObject, GetRundomPosToSpawn(), thrownObject.transform.rotation);

            objOfThrownObject.GetComponent<Rigidbody>().AddForce(GetRandomForce(), ForceMode.Impulse);
            objOfThrownObject.GetComponent<Rigidbody>().AddTorque(GetRandomTorque(), ForceMode.Impulse);

            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    private Vector3 GetRundomPosToSpawn()
    {
        return transform.position + new Vector3(Random.Range(-_boundX, _boundX), 0, 0);
    }

    private Vector3 GetRandomForce()
    {
        return Vector3.up * Random.Range(_minForce, _maxForce);
    }

    private Vector3 GetRandomTorque()
    {
        float torqueX = Random.Range(-_torque, _torque);
        float torqueY = Random.Range(-_torque, _torque);
        float torqueZ = Random.Range(-_torque, _torque);

        return new Vector3(torqueX, torqueY, torqueZ);
    }

}
