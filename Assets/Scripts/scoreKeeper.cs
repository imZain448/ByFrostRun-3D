using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreKeeper : MonoBehaviour
{
    public int CurrentScore;
    public int ReSpawn = 0;
    public int ReSpawnMax;
    public x2_BarController x2Script;

    private void Start()
    {
        x2Script = FindObjectOfType<x2_BarController>();
    }

    void GetScore()
    {
        if(x2Script.x2_active)
        {
            CurrentScore = CurrentScore * 2;
        }
    }
}
