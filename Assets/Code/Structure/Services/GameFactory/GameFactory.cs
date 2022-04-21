using UnityEngine;
using Zenject;

public class GameFactory : IGameFactory
{
    private AssetProvider _assetProvider;

    [Inject]
    public void Construct(AssetProvider assetProvider)
    {
        _assetProvider = assetProvider;
    }

    public Enemy CreateEnemy(EnemyType enemyType, Vector3 position, Transform parent = null)
    {
        GameObject enemyObject = _assetProvider.Instantiate(enemyType.PrefabPath, position, Quaternion.identity);
        enemyObject.transform.SetParent(parent);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        return enemy;
    }

    public IProjectile CreateTurretShell(Vector3 position, Transform parent = null)
    {
        GameObject turretShell = _assetProvider.Instantiate(AssetPath.TurretShell, position, Quaternion.identity);
        turretShell.transform.SetParent(parent);
        IProjectile projectile = turretShell.GetComponent<IProjectile>();
        return projectile;
    }
}