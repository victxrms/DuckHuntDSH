using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public float life = 3;
    GameObject Pato;

    void Start()
    {
        Pato = GameObject.FindWithTag("Pato");
    }

    void Awake()
    {
        // Apuntar la bala hacia adelante
        transform.rotation = Quaternion.LookRotation(transform.forward);
        Destroy(gameObject, life);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    
        if(other.CompareTag("Pato"))
        {
            //Spawner.SendMessage("Patotocado");            
            //Diana.SendMessage("Sumar_puntos");
            

        }

        if(other.CompareTag("Puntos_extra"))
        {
            Destroy(other.gameObject);
            other.SendMessage("Puntos_extra");
        }

        if(other.CompareTag("Patos_lentos"))
        {
            Destroy(other.gameObject);
            Pato.SendMessage("Patos_lentos"); 
        }
    }   
}


