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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("collided");
        }
    }
}
