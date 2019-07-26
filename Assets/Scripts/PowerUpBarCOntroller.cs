using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpBarCOntroller : MonoBehaviour
{
    public RedCubePowerUp RedCubeScript;
    public float timeElapsed;
    private float FillAmmount;
    public Image PowerUpBar;
    public Text PowerUp;

    private void Start()
    {
        PowerUpBar = gameObject.GetComponent<Image>();
        timeElapsed = 0;
    }

    private void Update()
    {
        if (RedCubeScript.ProgressEnable)
        {
            if ((Time.time - RedCubeScript.SnapTime) < RedCubeScript.maxTime)
            {
                timeElapsed = RedCubeScript.maxTime - (Time.time - RedCubeScript.SnapTime);
                PowerUpBar.fillAmount =  (timeElapsed /RedCubeScript.maxTime);
            }
        }
    }
}
