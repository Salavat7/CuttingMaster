using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ThrownObjectsDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
