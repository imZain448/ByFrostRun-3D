using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RedCubePowerUp : MonoBehaviour
{
    private Vector3 PlayerOriginaSize;
    private Material PlayerOriginalMaterial;
    public Vector3 PowerUpSize = new Vector3(5 , 5, 5);

    [HideInInspector]
    public GameObject PlayerPrefab;
    public Material PowerUpmaterial;
    public GameObject ParticleEffect;

    [HideInInspector]
    public PowerUpBarCOntroller BarControllerScript;
    private GameObject effect;
    public AudioClip PowerUpSound;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefab = GameObject.FindGameObjectWithTag("Player");
        BarControllerScript = FindObjectOfType<PowerUpBarCOntroller>();
        PlayerOriginaSize = PlayerPrefab.transform.localScale;
        PlayerOriginalMaterial = PlayerPrefab.GetComponent<Renderer>().sharedMaterial;
        BarControllerScript.enabled = false;
        BarControllerScript.PowerUp.enabled = false;
        BarControllerScript.PowerUpBar.enabled = false;
        BarControllerScript.Background.enabled = false;
        BarControllerScript.hexbackground.enabled = false;
        BarControllerScript.ProgressEnable = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(PowerUpSound);
            BarControllerScript.initialTime = Time.time;
            BarControllerScript.MaxTime = 10f;
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

        if (!BarControllerScript.enabled)
            BarControllerScript.enabled = true;

        if(!BarControllerScript.PowerUp.enabled)
            BarControllerScript.PowerUp.enabled = true;

        if(!BarControllerScript.PowerUpBar.enabled)
            BarControllerScript.PowerUpBar.enabled = true;

        if(!BarControllerScript.Background.enabled)
            BarControllerScript.Background.enabled = true;

        if(!BarControllerScript.Background.enabled)
            BarControllerScript.hexbackground.enabled = true;

        if(!BarControllerScript.ProgressEnable)
           BarControllerScript.ProgressEnable = true;

        yield return new WaitForSeconds(BarControllerScript.MaxTime);

        BarControllerScript.ProgressEnable = false;
        BarControllerScript.PowerUpBar.enabled = false;
        BarControllerScript.PowerUp.enabled = false;
        BarControllerScript.Background.enabled = false;
        BarControllerScript.hexbackground.enabled = false;
        BarControllerScript.enabled = false;
        player.transform.localScale = PlayerOriginaSize;
        player.GetComponent<Renderer>().material = PlayerOriginalMaterial;
        player.gameObject.tag = "Player";
        Destroy(gameObject);
        Destroy(effect, 1f);
    }
}
