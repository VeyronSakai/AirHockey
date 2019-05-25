using UniRx;

public class GameStateManager
{
    //GameState.Homeで初期化
    private ReactiveProperty<GameState> currentGameState = new ReactiveProperty<GameState>(GameState.Home);

    public IReadOnlyReactiveProperty<GameState> CurrentGameState
    {
        get { return currentGameState; }
    }

    //状態を変更
    public void SetGameState(GameState state)
    {
        currentGameState.Value = state;
    }

}