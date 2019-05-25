using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Zenject;

public class PlayerWinJudger : MonoBehaviour
{
    [Inject] GameStateManager gameStateManager;

    [Inject] VictoryStateManager victoryStateManager;
    
    // Start is called before the first frame update
    void Start()
    {
        JudgePlayerWin();
    }

    private void JudgePlayerWin()
    {  
        this.OnTriggerEnterAsObservable()
            .Select(collision => collision.tag)
            .Where(collisionTag => collisionTag == "Pack")
            .Where(_ => gameStateManager.CurrentGameState.Value == GameState.Play)
            .Subscribe(_ => {
                gameStateManager.SetGameState(GameState.Result);
                victoryStateManager.SetVictoryState(VictoryState.Win);
            });
    }
}
