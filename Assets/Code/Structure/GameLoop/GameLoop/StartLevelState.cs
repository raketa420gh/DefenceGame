public class StartLevelState : GameLoopState
{
    private LevelLoop _levelLoop;
    private SquadFormater _squadFormater;
    private SquadFormationUI _squadFormationUI;
    private EnemySpawner _enemySpawner;
    private EnemyDetector _enemyDetector;

    public StartLevelState(GameLoop gameLoop,
        StateMachine stateMachine,
        SquadFormater squadFormater, 
        SquadFormationUI squadFormationUI,
        EnemySpawner enemySpawner,
        EnemyDetector enemyDetector)
        : base(gameLoop, stateMachine)
    {
        _squadFormater = squadFormater;
        _squadFormationUI = squadFormationUI;
        _enemySpawner = enemySpawner;
        _enemyDetector = enemyDetector;
    }

    public override void Enter()
    {
        base.Enter();
        
        CreateNewLevelLoop();
    }

    private void CreateNewLevelLoop()
    {
        _levelLoop = new LevelLoop(_squadFormationUI);
        _levelLoop.OnLevelStarted += OnLevelStarted;
        _levelLoop.OnLevelWon += OnLevelWon;
        _levelLoop.OnLevelLose += OnLevelLose;
        
        //_levelLoop.StartLevel();
    }
    
    private void OnLevelStarted()
    {
        _enemySpawner.StartSpawningEnemies(EnemyTier.Tier3, 1f);
    }

    private void OnLevelWon()
    {
        
    }

    private void OnLevelLose()
    {
        
    }
}