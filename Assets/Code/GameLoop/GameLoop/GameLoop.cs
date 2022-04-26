using UnityEngine;
using Zenject;

public class GameLoop : MonoBehaviour
{
    public StateMachine GameLoopStateMachine;
    public LoadLevelState LoadLevelState;
    public StartLevelState StartLevelState;
    public EndLevelState EndLevelState;
    
    private EnemySpawner _enemySpawner;
    private EnemyDetector _enemyDetector;

    [Inject]
    public void Construct(EnemySpawner enemySpawner, EnemyDetector enemyDetector)
    {
        _enemySpawner = enemySpawner;
        _enemyDetector = enemyDetector;
    }

    private void Start()
    {
        InitializeStateMachine();
    }

    private void InitializeStateMachine()
    {
        GameLoopStateMachine = new StateMachine();

        LoadLevelState = new LoadLevelState(this, GameLoopStateMachine);
        StartLevelState = new StartLevelState(this, GameLoopStateMachine, _enemySpawner, _enemyDetector);
        EndLevelState = new EndLevelState(this, GameLoopStateMachine);

        GameLoopStateMachine.ChangeState(LoadLevelState);
    }
}