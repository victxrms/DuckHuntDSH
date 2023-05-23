using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public float life = 3;
    GameObject Pato, Diana, Spawner;

    void Start()
    {
        Pato = GameObject.FindWithTag("Pato");
        Spawner = GameObject.FindWithTag("Spawner");
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
            Spawner.SendMessage("Patotocado");            
            Spawner.SendMessage("Sumar_puntos");
        }

        if(other.CompareTag("Puntos_extra"))
        {
            UnityEngine.Debug.Log("puntos extra");
            Destroy(other.gameObject);
            Spawner.SendMessage("Puntos_extra");
        }

        if(other.CompareTag("Patos_lentos"))
        {
            UnityEngine.Debug.Log("Patos lentos");
            Destroy(other.gameObject);
            Pato.SendMessage("Patos_lentos"); 
        }
    }   
}


