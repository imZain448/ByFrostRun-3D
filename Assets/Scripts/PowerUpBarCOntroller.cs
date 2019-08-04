using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpBarCOntroller : MonoBehaviour
{
    [HideInInspector]
    public bool ProgressEnable;

    [HideInInspector]
    public float initialTime;

    [HideInInspector]
    public float MaxTime;

    public float timeElapsed;
    private float FillAmmount;
    public Image PowerUpBar;
    public Image Background;
    public Image hexbackground;
    public Text PowerUp;

    private void Start()
    {;
        timeElapsed = 0;
    }

    private void Update()
    {
        if (ProgressEnable)
        {
            if ((Time.time - initialTime) < MaxTime)
            {
                timeElapsed = MaxTime - (Time.time - initialTime);
                PowerUpBar.fillAmount =  (timeElapsed /MaxTime);
            }
        }
    }
}
