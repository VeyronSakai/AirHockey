using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using DG.Tweening;

public class StartButton : MonoBehaviour
{
    private Button button;

    [Inject] private GameStateManager gameStateManager;

    [SerializeField] private CanvasGroup HomeUI;

    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<Button>();

        button.onClick.AddListener(PushStartButton);
    }

    private void PushStartButton()
    {
        //HomeUIをフェードアウトさせる。
        //アニメーション終了時にStartGame()を実行
        HomeUI
            .DOFade(0, 1.0f)
            .OnComplete(StartGame);
    }

    private void StartGame()
    {
        //GameStateの更新
        gameStateManager.SetGameState(GameState.Start);
    }
}
