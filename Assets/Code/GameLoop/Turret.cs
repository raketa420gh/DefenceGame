using UnityEngine;
using Zenject;

public class Turret : MonoBehaviour, IFirearms
{
    [SerializeField] private Transform _muzzle;
    private TurretAim _aim;
    private EnemyDetector _detector;
    private IProjectile _shell;
    private GameFactory _gameFactory;

    [Inject]
    public void Construct(GameFactory gameFactory)
    {
        _gameFactory = gameFactory;
    }

    private void Awake()
    {
        _detector = GetComponent<EnemyDetector>();
        _aim = GetComponentInChildren<TurretAim>();
    }

    public void ShootToTarget()
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