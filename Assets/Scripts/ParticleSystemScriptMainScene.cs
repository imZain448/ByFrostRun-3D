using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemScriptMainScene : MonoBehaviour
{
    private Vector3 startOffsetParticle;
    private Vector3 motionVectorParticle;
    private Transform LookAtParticle;
    public GameObject mainCamera;

    void Start()
    {
        LookAtParticle = mainCamera.GetComponent<Transform>();
        startOffsetParticle =  gameObject.transform.position - mainCamera.transform.position ;
    }

    // Update is called once per frame
    void Update()
    {
        motionVectorParticle.x = gameObject.transform.position.x;
        motionVectorParticle.y = gameObject.transform.position.y;
        motionVectorParticle.z = LookAtParticle.position.z + startOffsetParticle.z;

        gameObject.transform.position = motionVectorParticle;
    }
}
