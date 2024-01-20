using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
   
    void Start()
    {
        
    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Obstacle" )
        {
            ReferenceSingleton.Instance.ChangeTime(5);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            ReferenceSingleton.Instance.ChangeTime(5);
        }
    }
}
