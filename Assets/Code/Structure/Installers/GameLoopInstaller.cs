using UnityEngine;
using Zenject;

public class GameLoopInstaller : MonoInstaller
{
    public GameLoop GameLoopPrefab;
    
    public override void InstallBindings()
    {
        BindGameLoop();
    }

    private void BindGameLoop()
    {
        GameLoop gameLoop = Container
            .InstantiatePrefabForComponent<GameLoop>(GameLoopPrefab,
            Vector3.zero, Quaternion.identity, null);

        Container
            .Bind<GameLoop>()
            .FromInstance(gameLoop)
            .AsSingle();
    }
}