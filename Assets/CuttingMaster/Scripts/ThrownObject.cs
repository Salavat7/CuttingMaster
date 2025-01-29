using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class ThrownObject : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    public void PlayParticle()
    {
        Instantiate(_particleSystem, transform.position, _particleSystem.transform.rotation);
    }

}
