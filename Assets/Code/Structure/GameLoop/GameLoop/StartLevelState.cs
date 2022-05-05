public class StartLevelState : GameLoopState
{
    private LevelLoop _levelLoop;
    private SquadFormater _squadFormater;
    private EnemySpawner _enemySpawner;
    private EnemyDetector _enemyDetector;

    public StartLevelState(GameLoop gameLoop,
        StateMachine stateMachine,
        SquadFormater squadFormater,
        EnemySpawner enemySpawner,
        EnemyDetector enemyDetector)
        : base(gameLoop, stateMachine)
    {
        _squadFormater = squadFormater;
        _enemySpawner = enemySpawner;
        _enemyDetector = enemyDetector;
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
        
        //_levelLoop.StartLevel();
    }
    
    private void OnLevelStarted()
    {
        //_squadFormation.LoadSquadPreset();
        //_enemySpawner.StartSpawningEnemies(EnemyTier.Tier3, 0.5f);
    }

    private void OnLevelWon()
    {
        
    }

    private void OnLevelLose()
    {
        
    }
}