using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    //hold multiple paths transform[][]
    public Transform[] path;
    public Transform startPoint;

    private void Awake()
    {
        main = this;
    }
}
