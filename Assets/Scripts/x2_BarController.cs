using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class x2_BarController : MonoBehaviour
{
    public CollectibleGreen collectibleGreenScript;
    public Text BarText;
    public Image progressBar;
    public float TimeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        progressBar = gameObject.GetComponent<Image>();
        TimeElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(collectibleGreenScript.x2_active)
        {
            if((Time.time - collectibleGreenScript.initialTime) < collectibleGreenScript.WaitTime)
            {
                TimeElapsed = Time.time - collectibleGreenScript.initialTime;
                progressBar.fillAmount =1 -  TimeElapsed / collectibleGreenScript.WaitTime;
            }
        }
    }
}
