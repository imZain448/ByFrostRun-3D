using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObjectScript : MonoBehaviour
{
    public GameObject remains;
    public Vector3 spawnPosition;
    private GameObject RemainPost;
    private GameObject postEffect;
    public GameObject explosionEffect;
    public AudioClip explosionSound;
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Immortal"))
        {
            StartCoroutine(destroyEffect(other));
        }
    }

    IEnumerator destroyEffect(Collider player)
    {
        spawnPosition = transform.position;
        RemainPost = Instantiate(remains, spawnPosition, transform.rotation);
        postEffect = Instantiate(explosionEffect, spawnPosition, transform.rotation);
        gameObject.GetComponent<AudioSource>().PlayOneShot(explosionSound);
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);

        Destroy(RemainPost);
        Destroy(postEffect);
    }
}
