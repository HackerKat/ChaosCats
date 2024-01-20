using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReferenceSingleton : Singleton<ReferenceSingleton>
{
    public Transform Player1;
    public Transform Player2;
    public Transform Background;
    public Transform Reticle;
    public bool Fusioned;

    public float FusionTimer = 10;

    

    public void ChangeTime(float newVal)
    {
        FusionTimer += newVal;
    }


}
