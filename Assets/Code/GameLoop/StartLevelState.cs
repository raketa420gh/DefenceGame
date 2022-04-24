public class StartLevelState : GameLoopState
{
    private LevelLoop _levelLoop;
    private EnemySpawner _enemySpawner;
    
    public StartLevelState(GameLoop gameLoop, StateMachine stateMachine) : base(gameLoop, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _levelLoop = new LevelLoop(gameLoop.EnemySpawner);
        gameLoop.SetCurrentLevelLoop(_levelLoop);
        _levelLoop.StartLevel();
        
        gameLoop.StartTurretShooting();
    }
}