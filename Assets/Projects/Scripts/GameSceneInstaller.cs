using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<GameStateManager>()
            .AsSingle();

        Container
            .Bind<VictoryStateManager>()
            .AsSingle();

        Container
            .Bind<InitializeManager>()
            .AsSingle();
    }
}