using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform LookAt;
    private Vector3 startOffset;
    private Vector3 motionVector;
    public GameObject player;

    private float transition = 0.0f;
    private float Animation = 2.0f;
    private Vector3 animationOffset = new Vector3(0, 5, 0);

   


    // Start is called before the first frame update
    void Start()
    {
        LookAt = player.GetComponent<Transform>();
        startOffset = transform.position - LookAt.position;
    }

    // Update is called once per frame
    void Update()
    {
        motionVector = LookAt.position + startOffset;
        motionVector.y = Mathf.Clamp(motionVector.y, 2, 8);
        if (transition >= 1.0f)
        {
            transform.position = motionVector;
        }
        else
        {
            transform.position = Vector3.Lerp(motionVector + animationOffset, motionVector, transition);
            transition += Time.deltaTime * 1 / Animation;
            transform.LookAt(LookAt.position, Vector3.up);
        }
    }
}
