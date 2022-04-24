using Zenject;

public class EnemySpawnerInstaller : MonoInstaller
{
    public EnemySpawner EnemySpawner; 
        
    public override void InstallBindings()
    {
        BindEnemySpawner();
    }

    private void BindEnemySpawner()
    {
        Container
            .Bind<EnemySpawner>()
            .FromInstance(EnemySpawner)
            .AsSingle();
    }
}

