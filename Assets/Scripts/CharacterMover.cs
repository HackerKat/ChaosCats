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
        if (ReferenceSingleton.Instance.Player2 && ReferenceSingleton.Instance.Player1)
            otherPlayer = FirstPlayer ? ReferenceSingleton.Instance.Player2 : ReferenceSingleton.Instance.Player1;
    }

    private void OnMove(InputValue moveVal)
    {
        if (!FirstPlayer) return;

        Vector2 movement = moveVal.Get<Vector2>();

        if (ReferenceSingleton.Instance.Fusioned)
        {
            Shoot(movement);
        }
        else
        {
            move1.x = movement.x;
            move1.y = movement.y;
        }
    }

    private void OnMove2(InputValue moveVal)
    {
        Debug.Log(FirstPlayer + " " + ReferenceSingleton.Instance.Fusioned, gameObject);
        Vector2 movement = moveVal.Get<Vector2>();

        if (!FirstPlayer)
        {
            move2.x = movement.x;
            move2.y = movement.y;
        }
        if (ReferenceSingleton.Instance.Fusioned)
        {
            move1.x = movement.x;
            move1.y = movement.y;
        }
    }

    private void FixedUpdate()
    {
        if (otherPlayer)
            FollowerOtherPlayer();

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
