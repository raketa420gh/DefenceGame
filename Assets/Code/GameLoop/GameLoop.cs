using UnityEngine;
using Zenject;

public class GameLoop : MonoBehaviour
{
    public StateMachine GameLoopStateMachine;
    public LoadLevelState LoadLevelState;
    public StartLevelState StartLevelState;
    public EndLevelState EndLevelState;

    private LevelLoop _currentLevelLoop;
    private EnemySpawner _enemySpawner;
    private Turret _turret;

    public EnemySpawner EnemySpawner => _enemySpawner;

    [Inject]
    public void Construct(EnemySpawner enemySpawner, Turret turret)
    {
        _enemySpawner = enemySpawner;
        _turret = turret;
    }

    private void Start()
    {
        InitializeStateMachine();
    }

    public void SetCurrentLevelLoop(LevelLoop levelLoop)
    {
        _currentLevelLoop = levelLoop;
    }

    public void StartTurretShooting()
    {
        InvokeRepeating(nameof(TurretShootToTarget), 0, 0.2f);
    }

    private void TurretShootToTarget()
    {
        _turret.ShootToTarget();
    }

    private void InitializeStateMachine()
    {
        GameLoopStateMachine = new StateMachine();

        LoadLevelState = new LoadLevelState(this, GameLoopStateMachine);
        StartLevelState = new StartLevelState(this, GameLoopStateMachine);
        EndLevelState = new EndLevelState(this, GameLoopStateMachine);

        GameLoopStateMachine.ChangeState(LoadLevelState);
    }
}