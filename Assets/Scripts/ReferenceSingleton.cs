using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceSingleton : Singleton<ReferenceSingleton>
{
    public Transform Player1;
    public Transform Player2;
    public Transform Background;
}
