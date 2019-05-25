using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Zenject;

public class PlayerMover : MonoBehaviour
{
    [Inject] private IInput input;

    [Inject] private GameStateManager gameStateManager;

    private Rigidbody rb;

    public float speed;

    private void Start() {

        rb = this.GetComponent<Rigidbody>();

        PlayerMove();
    }

    void PlayerMove()
    {
        this.UpdateAsObservable()
            .Subscribe(_ => rb.AddForce(input.MoveVector * speed))
            .AddTo(this);
    }
}
