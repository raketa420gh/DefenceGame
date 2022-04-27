using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class Firearms : MonoBehaviour, IFirearms
{
    [SerializeField] private Transform _muzzle;
    [SerializeField] private string _shellPath;
    [SerializeField] private Aim _aim;
    private GameFactory _gameFactory;

    [Inject]
    public void Construct(GameFactory gameFactory)
    {
        _gameFactory = gameFactory;
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
        else
            Debug.Log($"{gameObject} aim = null");
    }

    public void Shoot(Vector3 targetPosition)
    {
        IProjectile projectile = _gameFactory.CreateShell(_muzzle.position, _shellPath);
        projectile.SetTarget(targetPosition);
    }
}