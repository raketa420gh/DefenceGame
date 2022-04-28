using UnityEngine;

public class StartLevelState : GameLoopState
{
    private LevelLoop _levelLoop;
    private SquadFormation _squadFormation;
    private EnemySpawner _enemySpawner;
    private EnemyDetector _enemyDetector;

    public StartLevelState(GameLoop gameLoop,
        StateMachine stateMachine,
        SquadFormation squadFormation,
        EnemySpawner enemySpawner,
        EnemyDetector enemyDetector)
        : base(gameLoop, stateMachine)
    {
        _squadFormation = squadFormation;
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
        
        _levelLoop.StartLevel();
    }
    
    private void OnLevelStarted()
    {
        _squadFormation.LoadHeroes();
        _enemySpawner.StartSpawningEnemies(EnemyTier.Tier3, 1f);
    }

    private void OnLevelWon()
    {
        
    }

    private void OnLevelLose()
    {
        
    }
}