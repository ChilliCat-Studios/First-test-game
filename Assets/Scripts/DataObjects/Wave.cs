using UnityEngine;
using System;

[Serializable]
public class Wave
{
    public int waveIndex;
    public string waveName;
    public string waveDescription;
    //add difficulty var?
    public WaveInfo[] waveInfo;
}
