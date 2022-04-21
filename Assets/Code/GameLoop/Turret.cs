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

    private void Start()
    {
        InvokeRepeating(nameof(ShootForward), 0, 0.55f);
    }

    private void ShootForward()
    {
        if (_aim.Target.position != null)
            Shoot(_aim.Target.position);
    }

    public void Shoot(Vector3 targetPosition)
    {
        IProjectile projectile = _gameFactory.CreateTurretShell(_muzzle.position);
        projectile.SetTarget(targetPosition);
    }
}