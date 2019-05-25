using UnityEngine;
using Zenject;
using UnityEngine.UI;

public class RetryButton : MonoBehaviour
{
    [Inject] private GameStateManager gameStateManager;

    [Inject] private InitializeManager initializeManager;

    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<Button>();

        button.onClick.AddListener(PushRetryButton);
    }

    private void PushRetryButton()
    {
        initializeManager.GoToStartState();
    }

}
