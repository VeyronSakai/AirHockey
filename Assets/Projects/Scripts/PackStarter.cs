using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;

public class PackStarter : MonoBehaviour
{
    [Inject] private GameStateManager gameStateManager;

    private Rigidbody rb;

    [SerializeField] private float speed;

    // Start is called before the first frame updates
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        StartPack();
    }


    private void StartPack()
    {
        gameStateManager
            .CurrentGameState
            .Where(state => state == GameState.Play)
            .Take(1)
            .Subscribe(_ => ThrowPack())
            .AddTo(this);
    }

    private void ThrowPack()
    {
        Vector3 ThrowDirection = new Vector3(0, 0, -1) * speed;
        rb.AddForce(ThrowDirection);
    }
}
