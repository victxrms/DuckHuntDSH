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

    void OnTriggerEnter(Collision collision)
    {
        /*
        Destroy(collision.gameObject);
        Destroy(gameObject);
    
        if(collision.CompareTag("Pato"))
        {
            collision.SendMessage("Muerto");
        }

        if(collision.CompareTag("Puntos_extra"))
        {
            collision.SendMessage("Puntos_extra");
        }

        if(collision.CompareTag("Patos_lentos"))
        {
            collision.SendMessage("Patos_lentos");
        }
        */
    }
} 
