using UnityEngine;
using UniRx;
using Zenject;

public class StartUIController : MonoBehaviour
{
    [Inject] private GameStateManager gameStateManager;

    // Start is called before the first frame update
    void Start()
    {
        DisplayCountDownUI();

        HideCountDownUI();
    }

    //Start状態ならCountDownUIを表示
    private void DisplayCountDownUI()
    {
        gameStateManager
            .CurrentGameState
            .Where(state => state == GameState.Start)
            .Subscribe(_ => this.gameObject.SetActive(true))
            .AddTo(this);
    }

    //Start状態でないならCountDownUIを非表示にする
    private void HideCountDownUI()
    {
        gameStateManager
            .CurrentGameState
            .Where(state => state != GameState.Start)
            .Subscribe(_ => this.gameObject.SetActive(false))
            .AddTo(this);
    }
}
