using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CollectibleBlueScript : MonoBehaviour
{
    [HideInInspector]
    public scoreKeeper scoreKeeperScript;

    public GameObject effect;
    private GameObject dummyEffect;
    public AudioClip pickUpSound;

    private void Start()
    {
        scoreKeeperScript = FindObjectOfType<scoreKeeper>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Immortal"))
        {
            StartCoroutine(pickUp(other));
           
            if(scoreKeeperScript.ReSpawn < scoreKeeperScript.ReSpawnMax)
            {
                scoreKeeperScript.ReSpawn += 1;
            }
        }
    }

    IEnumerator pickUp(Collider player)
    {
        dummyEffect =  Instantiate(effect, transform.position, transform.rotation);
        gameObject.GetComponent<AudioSource>().PlayOneShot(pickUpSound);
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(1.2f);

        Destroy(gameObject);
        Destroy(dummyEffect);
    }
}
