using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;

public class LoseTextDisplayer : MonoBehaviour
{
    [Inject] private VictoryStateManager victoryStateManager;

    // Start is called before the first frame update
    void Start()
    {
        DisplayLoseText();

        HideLoseText();
    }

    private void DisplayLoseText()
    {
        victoryStateManager
            .CurrentVictoryState
            .Where(state => state == VictoryState.Lose)
            .Subscribe(_ => this.gameObject.SetActive(true))
            .AddTo(this);
    }

    private void HideLoseText()
    {
        victoryStateManager
            .CurrentVictoryState
            .Where(state => state != VictoryState.Lose)
            .Subscribe(_ => this.gameObject.SetActive(false))
            .AddTo(this);
    }
}
