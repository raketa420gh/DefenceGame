public class StartLevelState : GameLoopState
{
    private LevelLoop _levelLoop;
    private EnemySpawner _enemySpawner;
    private EnemyDetector _enemyDetector;
    private Turret _turret;
    
    public StartLevelState(GameLoop gameLoop, 
        StateMachine stateMachine, 
        EnemySpawner enemySpawner, 
        EnemyDetector enemyDetector, 
        Turret turret)
        : base(gameLoop, stateMachine)
    {
        _enemySpawner = enemySpawner;
        _enemyDetector = enemyDetector;
        _turret = turret;
    }

    public override void Enter()
    {
        base.Enter();
        
        StartNewLevel();
    }

    private void StartNewLevel()
    {
        _levelLoop = new LevelLoop(_enemyDetector);
        _levelLoop.OnLevelStarted += OnLevelStarted;
        _levelLoop.OnLevelWon += OnLevelWon;
        _levelLoop.OnLevelLose += OnLevelLose;
        
        _levelLoop.StartLevel();
    }
    
    private void OnLevelStarted()
    {
        _enemySpawner.StartSpawningEnemies(EnemyTier.Tier3, 1f);
        _turret.StartTurretShooting(0.5f);
    }

    private void OnLevelWon()
    {
        
    }

    private void OnLevelLose()
    {
        
    }
}