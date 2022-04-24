using System;
using UnityEngine;

public class Shell : MonoBehaviour, IProjectile
{
    public event Action<int> OnDamageInflicted;
    
    [SerializeField] [Min(0)] private int _damage = 10;
    [SerializeField] [Min(0)] private float _speed = 50f;
    [SerializeField] [Min(0)] private float _lifeTime = 3f;
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
        InflictDamage();
        Destroy(gameObject);
    }
    
    public void SetTarget(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
    }

    private void InflictDamage()
    {
        OnDamageInflicted?.Invoke(_damage);
    }
}