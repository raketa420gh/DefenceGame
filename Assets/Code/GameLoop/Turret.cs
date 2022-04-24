using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class Turret : MonoBehaviour, IFirearms
{
    [SerializeField] private Transform _muzzle;
    private TurretAim _aim;
    private EnemyDetector _enemyDetector;
    private IProjectile _shell;
    private GameFactory _gameFactory;

    [Inject]
    public void Construct(GameFactory gameFactory, EnemyDetector enemyDetector)
    {
        _gameFactory = gameFactory;
        _enemyDetector = enemyDetector;
        
        _aim = GetComponentInChildren<TurretAim>();
    }
    
    public async Task StartTurretShooting(float period, float startDelay = 0f)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(startDelay));

        while (true)
        {
            ShootToTarget();
            await UniTask.Delay(TimeSpan.FromSeconds(period));
        }
    }

    private void ShootToTarget()
    {
        if (_aim.Target != null)
        {
            Vector3 offset = Vector3.up / 2;
            Shoot(_aim.Target.position + offset);
        }
    }

    public void Shoot(Vector3 targetPosition)
    {
        IProjectile projectile = _gameFactory.CreateTurretShell(_muzzle.position);
        projectile.SetTarget(targetPosition);
    }
}