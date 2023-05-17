using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public float life = 3;

    void Awake()
    {
        // Apuntar la bala hacia adelante
        transform.rotation = Quaternion.LookRotation(transform.forward);
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
