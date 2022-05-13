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
    [SerializeField] private List<EnemyData> _enemyTypes;
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
        List<EnemyData> enemyTypes = _enemyTypes.Where(enemyType => enemyType.Tier == enemyTier).ToList();

        int randomIndex = Random.Range(0, enemyTypes.Count);
        EnemyData randomEnemyData = enemyTypes[randomIndex];

        _enemyID++;
        Enemy enemy = SpawnEnemy(randomEnemyData, GetRandomSpawnPoint());
        enemy.gameObject.name = $"{randomEnemyData.Name} {_enemyID}";
    }

    private Enemy SpawnEnemy(EnemyData enemyData, SpawnPoint point)
    {
        return _gameFactory.CreateEnemy(enemyData, point.Position);
    }

    private SpawnPoint GetRandomSpawnPoint()
    {
        var randomIndex = Random.Range(0, _spawnPoints.Count);
        var randomSpawnPoint = _spawnPoints[randomIndex];
        return randomSpawnPoint;
    }
}