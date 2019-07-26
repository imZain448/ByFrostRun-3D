using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreKeeper : MonoBehaviour
{
    public int CurrentScore;
    public int ReSpawn = 0;
    public int ReSpawnMax;
    public CollectibleGreen collectibleGreenScript;
    void GetScore()
    {
        if(collectibleGreenScript.x2_active)
        {
            CurrentScore = CurrentScore * 2;
        }
    }
}
