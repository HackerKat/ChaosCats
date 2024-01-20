using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player1;
    private Transform player2;

    private Transform parentTransform;

    private void Start()
    {
        player1 = ReferenceSingleton.Instance.Player1;
        player2 = ReferenceSingleton.Instance.Player2;
    }

    private void Update()
    {
        SelectBestPlayer();
        // Freeze the Y-axis position of the child
        Vector3 newPosition = transform.position;
        newPosition.y = parentTransform.position.y;
        transform.position = newPosition;
    }

    private void SelectBestPlayer()
    {
        parentTransform = player1.position.y > player2.position.y ? player1 : player2;
    }
}
