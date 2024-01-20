using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnController : MonoBehaviour
{
    private Transform background;
    private Transform player1;
    private Transform player2;

    private void Start()
    {
        background = ReferenceSingleton.Instance.Background;
        player1 = ReferenceSingleton.Instance.Player1;
        player2 = ReferenceSingleton.Instance.Player2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);

        background.eulerAngles += new Vector3(0, 180, 180);

        Vector3 currentPosition = player1.position;
        currentPosition.y = 0;
        player1.position = currentPosition;
        currentPosition = player2.position;
        currentPosition.y = 0;
        player2.position = currentPosition;
    }
}
