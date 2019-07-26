using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RedCubePowerUp : MonoBehaviour
{
    private Vector3 PlayerOriginaSize;
    public bool ProgressEnable = false;
    public float maxTime;
    public float SnapTime;
    private Material PlayerOriginalMaterial;
    public Vector3 PowerUpSize = new Vector3(5 , 5, 5);
    public GameObject PlayerPrefab;
    public Material PowerUpmaterial;
    public GameObject ParticleEffect;
    public PowerUpBarCOntroller BarControllerScript;
    private GameObject effect;
    public AudioClip PowerUpSound;

    // Start is called before the first frame update
    void Start()
    {
        PlayerOriginaSize = PlayerPrefab.transform.localScale;
        PlayerOriginalMaterial = PlayerPrefab.GetComponent<Renderer>().sharedMaterial;
        BarControllerScript.enabled = false;
        BarControllerScript.PowerUp.enabled = false;
        BarControllerScript.PowerUpBar.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(PowerUpSound);
            SnapTime = Time.time;
            maxTime = 10f;
            StartCoroutine(PickUp(other));
        }
    }

    private IEnumerator PickUp(Collider player)
    {
        player.gameObject.tag = "Immortal";
        effect = Instantiate(ParticleEffect, transform.position +   new Vector3(0,0,1), transform.rotation);
        player.transform.localScale = PowerUpSize;
        player.GetComponent<Renderer>().material = PowerUpmaterial;
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<Renderer>().enabled = false;
        BarControllerScript.enabled = true;
        BarControllerScript.PowerUp.enabled = true;
        BarControllerScript.PowerUpBar.enabled = true;
        ProgressEnable = true;

        yield return new WaitForSeconds(maxTime);

        ProgressEnable = false;
        BarControllerScript.PowerUpBar.enabled = false;
        BarControllerScript.PowerUp.enabled = false;
        BarControllerScript.enabled = false;
        player.transform.localScale = PlayerOriginaSize;
        player.GetComponent<Renderer>().material = PlayerOriginalMaterial;
        player.gameObject.tag = "Player";
        Destroy(gameObject);
        Destroy(effect, 1f);
    }
}
