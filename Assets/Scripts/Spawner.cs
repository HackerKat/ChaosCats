using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstacleType;
    [SerializeField] private Transform startPosition;
    public int spawnAmount = 10;
    private int spawnedObjects = 0;
    void Start()
    {
        StartCoroutine(Spawning());
    }

    // Update is called once per frame
    void Update()
    {
        
       

    }

    private IEnumerator Spawning()
    {
        float randomInterval = Random.Range(0f, 4f);
        while (true)
        {
            yield return new WaitForSeconds(randomInterval);

            if (spawnedObjects < spawnAmount)
            {
                int r = Random.Range(0, obstacleType.Count);

                Vector3 randomPos = new Vector3(startPosition.position.x + Random.Range(1f, 20f), startPosition.position.y, 0f);
                float randomZRotation = Random.Range(0f, 360f);
                Quaternion randomRot =Quaternion.Euler(Quaternion.identity.x, Quaternion.identity.y, randomZRotation);


                Instantiate(obstacleType[r], randomPos, randomRot, this.transform);

                spawnedObjects++;
            }
            else
            {
                // Reset the counter after one minute
                spawnedObjects = 0;
            }
        }
    }
}
