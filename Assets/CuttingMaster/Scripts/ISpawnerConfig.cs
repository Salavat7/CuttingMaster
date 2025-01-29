using UnityEngine;

public interface ISpawnerConfig
{
    public int SpawnDelay { get; }
    public int BoundX { get; }
    public Vector3 ForceToThrow { get; }
    public Vector3 Position { get; }
}
