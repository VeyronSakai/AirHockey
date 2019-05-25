using Zenject;

public class InitializeManager
{
    [Inject] private GameStateManager gameStateManager;

    public void GoToStartState()
    {
        gameStateManager.SetGameState(GameState.Start);
    }

    public void GoToHomeState()
    {
        gameStateManager.SetGameState(GameState.Home);
    }

}
