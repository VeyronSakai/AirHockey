using UnityEngine;
using Zenject;
using UniRx;

public class ResultUIController : MonoBehaviour
{
    [Inject] private GameStateManager gameStateManager;

    // Start is called before the first frame update
    void Start()
    {
        DisplayResultUI();

        HideResultUI();
    }

    private void DisplayResultUI()
    {
        gameStateManager
            .CurrentGameState
            .Where(state => state == GameState.Result)
            .Subscribe(_ => this.gameObject.SetActive(true))
            .AddTo(this);
    }

    private void HideResultUI()
    {
        gameStateManager
            .CurrentGameState
            .Where(state => state != GameState.Result)
            .Subscribe(_ => this.gameObject.SetActive(false))
            .AddTo(this);
    }

}
