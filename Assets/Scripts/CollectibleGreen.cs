using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CollectibleGreen : MonoBehaviour
{
   
    public GameObject effect;
    public AudioClip pickUpSound;

    [HideInInspector]
    public x2_BarController ProgressBarScript;

    private void Start()
    {
        ProgressBarScript = FindObjectOfType<x2_BarController>();
        ProgressBarScript.progressBar.enabled = false;
        ProgressBarScript.BarText.enabled = false;
        ProgressBarScript.background.enabled = false;
        ProgressBarScript.hexBackground.enabled = false;
    }

    IEnumerator x2_pickUp(Collider player)
    {
        Instantiate(effect, transform.position, transform.rotation);
        gameObject.GetComponent<AudioSource>().PlayOneShot(pickUpSound);
        ProgressBarScript.x2_active = true;
        ProgressBarScript.initialTime = Time.time;
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        ProgressBarScript.progressBar.enabled = true;
        ProgressBarScript.BarText.enabled = true;
        ProgressBarScript.background.enabled = true;
        ProgressBarScript.hexBackground.enabled = true;

        yield return new WaitForSeconds(ProgressBarScript.WaitTime);

        ProgressBarScript.background.enabled = false;
        ProgressBarScript.hexBackground.enabled = false;
        ProgressBarScript.BarText.enabled = false;
        ProgressBarScript.progressBar.enabled = false;
        ProgressBarScript.x2_active = false;
        Destroy(gameObject);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Immortal"))
        {
            ProgressBarScript.WaitTime = 10f;
            StartCoroutine(x2_pickUp(other));
        }
    }
}
