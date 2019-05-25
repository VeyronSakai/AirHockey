using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;

public class HomeUIController : MonoBehaviour
{
    [Inject] private GameStateManager gameStateManager;

    // Start is called before the first frame update
    void Start()
    {
        DisplayHomeUI();

        HideHomeUI();
    }

    //Start状態ならHomeUIを表示
    private void DisplayHomeUI()
    {
        gameStateManager
            .CurrentGameState
            .Where(state => state == GameState.Home)
            .Subscribe(_ => this.gameObject.SetActive(true))
            .AddTo(this);
    }

    //Start状態でないならHomeUIを非表示にする
    private void HideHomeUI()
    {
        gameStateManager
            .CurrentGameState
            .Where(state => state != GameState.Home)
            .Subscribe(_ => this.gameObject.SetActive(false))
            .AddTo(this);
    }
}
