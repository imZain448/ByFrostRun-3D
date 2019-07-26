using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRemains : MonoBehaviour
{
    public GameObject destroyRemainsEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Remains"))
        {
             Destroy(collision.gameObject);
             Instantiate(destroyRemainsEffect, transform.position, transform.rotation);

        }
    }
}
