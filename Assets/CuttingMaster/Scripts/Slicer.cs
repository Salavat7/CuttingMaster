using UnityEngine;

[RequireComponent(typeof(TrailRenderer), typeof(SphereCollider))]
public class Slicer : MonoBehaviour
{
    [SerializeField] private Transform _spawnerPos;
    
    private TrailRenderer _trail;
    private SphereCollider _sphereCollider;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        _trail = gameObject.GetComponent<TrailRenderer>();
        _sphereCollider = gameObject.GetComponent<SphereCollider>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _trail.enabled = true;
            _sphereCollider.enabled = true;

            Vector3 mousePos = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
            mousePos.z = _spawnerPos.position.z;
            transform.position = mousePos;
        }
        else
        {
            _trail.enabled = false;
            _sphereCollider.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<ThrownObject>(out ThrownObject thrownObject))
        {
            thrownObject.PlayParticle();
            Destroy(thrownObject.gameObject);
        }
    }
}
