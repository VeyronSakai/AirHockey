using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Zenject;

public class PlayerLoseJudger : MonoBehaviour
{
    [Inject] GameStateManager gameStateManager;

    [Inject] VictoryStateManager victoryStateManager;

    // Start is called before the first frame update
    void Start()
    {
        JudgePlayerLose();
    }

    private void JudgePlayerLose()
    {
        this.OnTriggerEnterAsObservable()
            .Select(collision => collision.tag)
            .Where(collisionTag => collisionTag == "Pack")
            .Where(_ => gameStateManager.CurrentGameState.Value == GameState.Play)
            .Subscribe(_ => {
                gameStateManager.SetGameState(GameState.Result);
                victoryStateManager.SetVictoryState(VictoryState.Lose);
            });
    }
}
