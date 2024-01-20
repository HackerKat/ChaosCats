using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleController : MonoBehaviour
{
    public float Delay = 3;

    void Start()
    {
        Destroy(gameObject, Delay);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstale"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
