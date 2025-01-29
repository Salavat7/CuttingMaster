using UnityEngine;

[CreateAssetMenu(fileName = "SpawnerConfig", menuName = "Scriptable Objects/SpawnerConfig")]
public class SpawnerConfig : ScriptableObject, ISpawnerConfig
{
    [field: SerializeField] public int SpawnDelay { get; private set; }
    [field: SerializeField] public int BoundX { get; private set; }
    [field: SerializeField] public Vector3 ForceToThrow { get; private set; }
    [field: SerializeField] public Vector3 Position { get; private set; }
}
