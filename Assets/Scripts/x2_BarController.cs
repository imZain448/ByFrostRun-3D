using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class x2_BarController : MonoBehaviour
{
    [HideInInspector]
    public bool x2_active;

    [HideInInspector]
    public float initialTime;

    [HideInInspector]
    public float WaitTime;
    public Text BarText;

    [HideInInspector]
    public Image progressBar;
    public Image background;
    public Image hexBackground;
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
        if(x2_active)
        {
            if((Time.time - initialTime) < WaitTime)
            {
                TimeElapsed = Time.time - initialTime;
                progressBar.fillAmount =1 -  TimeElapsed / WaitTime;
            }
        }
    }
}
