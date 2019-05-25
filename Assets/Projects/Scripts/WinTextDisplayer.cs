using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;

public class WinTextDisplayer : MonoBehaviour
{
    [Inject] private VictoryStateManager victoryStateManager;

    // Start is called before the first frame update
    void Start()
    {
        DisplayWinText();

        HideWinText();
    }

    private void DisplayWinText()
    {
        victoryStateManager
            .CurrentVictoryState
            .Where(state => state == VictoryState.Win)
            .Subscribe(_ => this.gameObject.SetActive(true))
            .AddTo(this);
    }

    private void HideWinText()
    {
        victoryStateManager
            .CurrentVictoryState
            .Where(state => state != VictoryState.Win)
            .Subscribe(_ => this.gameObject.SetActive(false))
            .AddTo(this);
    }
}
