using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMover : MonoBehaviour
{
    public bool FirstPlayer = true;
    public float Speed = 2;
    public float MaxDistanceToOther = 5;

    public bool Fusioned;

    private Vector3 move1;
    private Vector3 move2;

    private Transform otherPlayer;

    private void Start()
    {
        if (ReferenceSingleton.Instance.Player2 && ReferenceSingleton.Instance.Player1)
            otherPlayer = FirstPlayer ? ReferenceSingleton.Instance.Player2 : ReferenceSingleton.Instance.Player1;
    }

    private void OnMove(InputValue moveVal)
    {
        Vector2 movement = moveVal.Get<Vector2>();

        move1.x = movement.x;
        move1.y = movement.y;

        if (Fusioned)
            Shoot(movement);
    }

    private void OnMove2(InputValue moveVal)
    {
        Vector2 movement = moveVal.Get<Vector2>();

        move2.x = movement.x;
        move2.y = movement.y;
    }

    private void FixedUpdate()
    {
        FollowerOtherPlayer();

        if (Fusioned && FirstPlayer)
        {
            return;
        }

        Vector3 movement = FirstPlayer ? move1 : move2;
        transform.position += Speed * Time.fixedDeltaTime * movement;


    }

    private void FollowerOtherPlayer()
    {
        bool otherIsHigher = otherPlayer.position.y > transform.position.y;
        if (!otherIsHigher) return;

        float yDistance = Mathf.Abs(otherPlayer.position.y - transform.position.y);

        if (yDistance > MaxDistanceToOther)
        {
            float newYPosition = Mathf.MoveTowards(transform.position.y, otherPlayer.position.y, Speed * Time.deltaTime);
            Vector3 newPosition = new Vector3(transform.position.x, newYPosition, transform.position.z);
            transform.position = newPosition;
        }
    }

    private void Shoot(Vector2 shootDirection)
    {
        GameObject reticle = Instantiate(ReferenceSingleton.Instance.Reticle, transform.position, Quaternion.identity).gameObject;
        Rigidbody2D rb = reticle.GetComponent<Rigidbody2D>();

        rb.AddForce(shootDirection.normalized * 10, ForceMode2D.Impulse);
    }
}
