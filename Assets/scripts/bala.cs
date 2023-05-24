using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    // Declaramos variables
    public float life = 3;
    GameObject Pato, Spawner;

    void Start()
    {
        // Cogemos los gameobjects a lo que le vamos a enviar mensajes
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
        // Destruimos la bala
        Destroy(gameObject);

        // Miramos si el gameobject con el que ha impactado tiene "Pato" de tag 
        if(other.CompareTag("Pato"))
        {
            // si lo tiene le mandamos al spawner que ejecute los metodos "Patotocado" y "Sumar_puntos" 
            Spawner.SendMessage("Patotocado");            
            Spawner.SendMessage("Sumar_puntos");
        }
        // Miramos si el gameobject impactado tiene en el tag "Puntos_extra"
        if(other.CompareTag("Puntos_extra"))
        {
            //Destruimos el objeto con el que se ha impactado y le mandamos al spawner el mensaje "Puntos_extra"
            UnityEngine.Debug.Log("puntos extra");
            Destroy(other.gameObject);
            Spawner.SendMessage("Puntos_extra");
        }

        // Miramos si el gameobject impactado tiene en el tag "Patos_lentos"
        if(other.CompareTag("Patos_lentos"))
        {
            //Destruimos el objeto y le mandamos al pato que esta en pantalla actualmente el mensaje "Patos_lentos"
            UnityEngine.Debug.Log("Patos lentos");
            Destroy(other.gameObject);
            Pato.SendMessage("Patos_lentos"); 
        }
    }   
}


