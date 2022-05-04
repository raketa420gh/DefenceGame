using System;
using Pathfinding;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> OnDead;

    [SerializeField] private EnemyData enemyData;
    [SerializeField] private AIPath _aiPath;
    [SerializeField] private Seeker _seeker;
    private Health _health;
    
    private void Awake()
    {
        _aiPath.maxSpeed = enemyData.MoveSpeed;
        _health = GetComponent<Health>();
        
        _health.Setup(enemyData.Health);

        _health.OnOver += OnHealthOver;
    }

    private void OnEnable()
    {
        var finishArea = FindObjectOfType<FinishArea>();
        _aiPath.destination = finishArea.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        var shell = other.GetComponent<Shell>();

        if (shell)
            shell.OnDamageInflicted += OnDamaged;
    }

    private void OnDisable()
    {
        OnDead?.Invoke(this);
    }

    private void TakeDamage(int amount)
    {
        _health.ChangeHealth(amount);
    }

    private void OnDamaged(int amount)
    {
        TakeDamage(amount);
    }

    private void OnHealthOver()
    {
        Destroy(gameObject);
    }
}