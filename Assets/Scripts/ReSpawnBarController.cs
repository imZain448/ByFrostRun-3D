using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReSpawnBarController : MonoBehaviour
{
    [HideInInspector]
    public scoreKeeper scoreKeeperScript;
    private Image progressBar;
    private void Start()
    {
        scoreKeeperScript = FindObjectOfType<scoreKeeper>();
        progressBar = gameObject.GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    {
        progressBar.fillAmount = (float)scoreKeeperScript.ReSpawn / scoreKeeperScript.ReSpawnMax;
    }
}
