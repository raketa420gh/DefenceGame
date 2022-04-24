using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

public class StartLevelState : GameLoopState
{
    private LevelLoop _levelLoop;
    private EnemySpawner _enemySpawner;
    private Turret _turret;
    
    public StartLevelState(GameLoop gameLoop, StateMachine stateMachine, EnemySpawner enemySpawner, Turret turret) : base(gameLoop, stateMachine)
    {
        _enemySpawner = enemySpawner;
        _turret = turret;
    }

    public override void Enter()
    {
        base.Enter();
        _levelLoop = new LevelLoop(_enemySpawner);
        _levelLoop.StartLevel();
        StartTurretShooting(0.2f);
    }

    private void TurretShootToTarget()
    {
        _turret.ShootToTarget();
    }
    
    private async Task StartTurretShooting(float period, float startDelay = 0f)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(startDelay));

        while (true)
        {
            TurretShootToTarget();
            await UniTask.Delay(TimeSpan.FromSeconds(period));
        }
    }
}