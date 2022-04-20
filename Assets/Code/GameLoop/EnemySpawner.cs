using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private EnemyType _warrior;
    private GameFactory _gameFactory;
    int _enemyID;

    [Inject]
    public void Construct(GameFactory gameFactory)
    {
        _gameFactory = gameFactory;
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnWarrior), 0, 5);
    }

    public void SpawnWarrior()
    {
        SpawnEnemyInRandomSpawnPoint(_warrior);
    }

    private void SpawnEnemyInRandomSpawnPoint(EnemyType enemyType)
    {
        Enemy enemy = SpawnEnemy(enemyType, GetRandomSpawnPoint());
        _enemyID++;
        enemy.gameObject.name = $"{enemyType.Name} {_enemyID}";
    }

    private Enemy SpawnEnemy(EnemyType enemyType, SpawnPoint point)
    {
        return _gameFactory.CreateEnemy(enemyType, point.Position);
    }

    private SpawnPoint GetRandomSpawnPoint()
    {
        var randomIndex = Random.Range(0, _spawnPoints.Count);
        var randomSpawnPoint = _spawnPoints[randomIndex];
        return randomSpawnPoint;
    }
}