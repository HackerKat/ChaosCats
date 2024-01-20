using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMover : MonoBehaviour
{
    public bool FirstPlayer = true;
    public float Speed = 2;
    public float MaxDistanceToOther = 5;

    private Vector3 move1;
    private Vector3 move2;

    private Transform otherPlayer;

    private void Start()
    {
        otherPlayer = FirstPlayer ? ReferenceSingleton.Instance.Player2 : ReferenceSingleton.Instance.Player1;
    }

    private void OnMove(InputValue moveVal)
    {
        Vector2 movement = moveVal.Get<Vector2>();

        move1.x = movement.x;
        move1.y = movement.y;
    }

    private void OnMove2(InputValue moveVal)
    {
        Vector2 movement = moveVal.Get<Vector2>();

        move2.x = movement.x;
        move2.y = movement.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = FirstPlayer ? move1 : move2;
        transform.position += Speed * Time.fixedDeltaTime * movement;

        FollowerOtherPlayer();
    }

    private void FollowerOtherPlayer()
    {
        float yDistance = Mathf.Abs(otherPlayer.position.y - transform.position.y);
        
        if (yDistance > MaxDistanceToOther)
        {
            Debug.Log(yDistance);
            // Calculate the direction to move
            Vector3 moveDirection = (otherPlayer.position - transform.position).normalized;
            moveDirection.y = 0; // Restrict movement to the Y-axis

            // Move the object towards the higher object
            transform.position += moveDirection * Speed * Time.deltaTime;
        }
    }
}
