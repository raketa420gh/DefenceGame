using UnityEngine;

public class Projectile : MonoBehaviour, IProjectile
{
    [SerializeField] private float _speed = 50f;
    [SerializeField] private float _lifeTime = 3f;
    private Vector3 _targetPosition;
    
    private void OnEnable()
    {
        Destroy(gameObject, _lifeTime);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
    
    public void SetTarget(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
    }
}
