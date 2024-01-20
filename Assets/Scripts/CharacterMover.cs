using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMover : MonoBehaviour
{
    public bool FirstPlayer = true;
    public float Speed = 2;

    private Vector3 move1;
    private Vector3 move2;

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
    }
}
