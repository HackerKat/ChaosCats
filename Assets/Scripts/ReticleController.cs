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

}
