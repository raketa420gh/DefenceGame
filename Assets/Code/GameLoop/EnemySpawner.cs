using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private List<EnemyType> _enemyTypes;
    private GameFactory _gameFactory;
    int _enemyID;

    [Inject]
    public void Construct(GameFactory gameFactory)
    {
        _gameFactory = gameFactory;
    }

    public async Task StartSpawningEnemies(EnemyTier tier, float period, float startDelay = 0f)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(startDelay));

        while (true)
        {
            SpawnEnemyInRandomSpawnPoint(tier);

            await UniTask.Delay(TimeSpan.FromSeconds(period));
        }
    }

    private void SpawnEnemyInRandomSpawnPoint(EnemyTier enemyTier)
    {
        List<EnemyType> enemyTypes = _enemyTypes.Where(enemyType => enemyType.Tier == enemyTier).ToList();

        int randomIndex = Random.Range(0, enemyTypes.Count);
        EnemyType randomEnemyType = enemyTypes[randomIndex];

        _enemyID++;
        Enemy enemy = SpawnEnemy(randomEnemyType, GetRandomSpawnPoint());
        enemy.gameObject.name = $"{randomEnemyType.Name} {_enemyID}";
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