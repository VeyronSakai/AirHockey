using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Zenject;

public class EnemyMover : MonoBehaviour
{
    [Inject] GameStateManager gameStateManager;

    [SerializeField] private PlayerMover playerMover;

    [SerializeField] private Transform packPosition;

    private float speed;

    private Rigidbody rb;

    private Vector3 leftVector;

    private Vector3 rightVector;

    // Start is called before the first frame update
    void Start()
    {
        leftVector = new Vector3(-1, 0, 0);

        rightVector = new Vector3(1, 0, 0);

        rb = this.GetComponent<Rigidbody>();

        this.speed = playerMover.speed;

        MoveEnemy();
    }

    private void MoveEnemy()
    {
        this.UpdateAsObservable()
            .Where(_ => gameStateManager.CurrentGameState.Value == GameState.Play)
            .Where(_ => packPosition.position.x < this.transform.position.x)
            .Subscribe(_ => rb.AddForce(leftVector * speed));

        this.UpdateAsObservable()
            .Where(_ => gameStateManager.CurrentGameState.Value == GameState.Play)
            .Where(_ => packPosition.position.x > this.transform.position.x)
            .Subscribe(_ => rb.AddForce(rightVector * speed));
    }
}
