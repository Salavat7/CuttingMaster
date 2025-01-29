using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ThrownObjects", menuName = "Scriptable Objects/ThrownObjects")]
public class ThrownObjects : ScriptableObject
{
    [field: SerializeField] public List<ThrownObject> ThrownObjectsList {get; private set;}

    public ThrownObject GetRandomThrownObj()
    {
        int index = Random.Range(0, ThrownObjectsList.Count);
        return ThrownObjectsList[index];
    }

}
