using System;
using Pathfinding;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> OnDead;

    [SerializeField] private EnemyType _enemyType;
    [SerializeField] private AIPath _aiPath;
    [SerializeField] private Seeker _seeker;
    
    private void Awake()
    {
        _aiPath.maxSpeed = _enemyType.MoveSpeed;
    }

    private void OnEnable()
    {
        var finishArea = FindObjectOfType<FinishArea>();
        _aiPath.destination = finishArea.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        var projectile = other.GetComponent<TurretShell>();

        if (projectile)
            Destroy(gameObject);
    }

    private void OnDisable()
    {
        OnDead?.Invoke(this);
    }
}