using UnityEngine;

public interface ISpawnerConfig
{
    public int SpawnDelay { get; }
    public int BoundX { get; }
    public float MinForce { get; }
    public float MaxForce { get; }
    public float Torque { get; }
}
