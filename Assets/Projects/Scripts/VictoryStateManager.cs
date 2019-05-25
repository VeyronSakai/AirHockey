using UniRx;

public class VictoryStateManager
{
    //ReactivePropertyで状態を管理
    //VictoryState.Otherで初期化
    private ReactiveProperty<VictoryState> currentVictoryState = new ReactiveProperty<VictoryState>(VictoryState.Other);

    public IReadOnlyReactiveProperty<VictoryState> CurrentVictoryState
    {
        get { return currentVictoryState; }
    }

    //状態を変更
    public void SetVictoryState(VictoryState state)
    {
        currentVictoryState.Value = state;
    }
}
