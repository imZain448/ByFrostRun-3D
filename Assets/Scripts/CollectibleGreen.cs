using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CollectibleGreen : MonoBehaviour
{
    public float WaitTime = 10f;
    public float initialTime;
    public bool x2_active = false;
    public GameObject effect;
    public AudioClip pickUpSound;
    public x2_BarController ProgressBarScript;

    private void Start()
    {
        ProgressBarScript.progressBar.enabled = false;
        ProgressBarScript.BarText.enabled = false;
    }

    IEnumerator x2_pickUp(Collider player)
    {
        Instantiate(effect, transform.position, transform.rotation);
        gameObject.GetComponent<AudioSource>().PlayOneShot(pickUpSound);
        x2_active = true;
        initialTime = Time.time;
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        ProgressBarScript.progressBar.enabled = true;
        ProgressBarScript.BarText.enabled = true;

        yield return new WaitForSeconds(WaitTime);

        ProgressBarScript.BarText.enabled = false;
        ProgressBarScript.progressBar.enabled = false;
        x2_active = false;
        Destroy(gameObject);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Immortal"))
        {
            StartCoroutine(x2_pickUp(other));
        }
    }
}
