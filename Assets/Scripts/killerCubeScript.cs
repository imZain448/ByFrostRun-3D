﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killerCubeScript : MonoBehaviour
{
    public GameObject PlayerRemains;
    private Transform PlayerTransform;
    public CameraMotor cameraMotorScript;
    private GameObject objectinstance;
    public AudioClip destroySound;
    public GameObject particleEffect;
    public GameObject cubeEffect;
    private GameObject dummyEffect;
    public CharacterMotor playerMotorScript;
    public Vector3 DestroyOffset = new Vector3(1, 1, 4);
    private Vector3 RemainTransform;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            PlayerTransform = gameObject.GetComponent<Transform>();

            playerMotorScript.enabled = false;

            RemainTransform = new Vector3(transform.position.x - DestroyOffset.x , 0.039f , transform.position.z);

            objectinstance = Instantiate(PlayerRemains, RemainTransform , PlayerTransform.rotation);
            gameObject.GetComponent<AudioSource>().PlayOneShot(destroySound);
            dummyEffect = Instantiate(particleEffect, RemainTransform, transform.rotation);

            cameraMotorScript.LookAt = gameObject.GetComponent<Transform>();
            
            Destroy(collision.gameObject);
            Destroy(dummyEffect, 1.5f);
            Instantiate(cubeEffect, RemainTransform, transform.rotation);
        }
    }
}
