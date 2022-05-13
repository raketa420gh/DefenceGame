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

    public Enemy CreateEnemy(EnemyData enemyData, Vector3 position, Transform parent = null)
    {
        GameObject enemyObject = _assetProvider.Instantiate(enemyData.PrefabPath, position, Quaternion.identity);
        enemyObject.transform.SetParent(parent);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        return enemy;
    }

    public Hero CreateHero(HeroData heroData, Vector3 position, Transform parent = null)
    {
        GameObject heroGameObject = _assetProvider.Instantiate(heroData.PrefabPath, position, Quaternion.identity);
        heroGameObject.transform.SetParent(parent);
        Hero hero = heroGameObject.GetComponent<Hero>();
        return hero;
    }

    public Turret CreateTurret(TurretData turretData, Vector3 position, Transform parent = null)
    {
        GameObject turretGameObject = _assetProvider.Instantiate(turretData.PrefabPath, position, Quaternion.identity);
        turretGameObject.transform.SetParent(parent);
        Turret turret = turretGameObject.GetComponent<Turret>();
        return turret;
    }

    public IProjectile CreateShell(Vector3 position, string path = AssetPath.Shell, Transform parent = null)
    {
        GameObject turretShell = _assetProvider.Instantiate(path, position, Quaternion.identity);
        turretShell.transform.SetParent(parent);
        IProjectile projectile = turretShell.GetComponent<IProjectile>();
        return projectile;
    }

    public GameObject CreateAbilityPointerSphere(Vector3 position, string path = AssetPath.AbilityPointerSphere,
        Transform parent = null)
    {
        GameObject pointer = _assetProvider.Instantiate(path, position, Quaternion.identity);
        pointer.transform.SetParent(parent);
        return pointer;
    }
}