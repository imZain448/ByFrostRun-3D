using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
    public Rigidbody player;
    public float speed = 1000f;
    public float sideforce = 20f;
    public float playerInput;

   
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        player.AddForce(0, 0, speed * Time.deltaTime);
        playerInput = Input.GetAxis("Horizontal");

        if (playerInput > 0)
        {
            player.AddForce(sideforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        else if(playerInput < 0)
        {
            player.AddForce(-sideforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
       
    }
}
