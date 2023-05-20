using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public float life = 3;
    public GameObject Patillo;
    public GameObject Diana;


    void Awake()
    {
        // Apuntar la bala hacia adelante
        transform.rotation = Quaternion.LookRotation(transform.forward);
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    
        if(other.gameObject.CompareTag("Pato"))
        {
            Diana.SendMessage("Sumar_puntos");
        }

        if(other.gameObject.CompareTag("Puntos_extra"))
        {
            Diana.SendMessage("Puntos_extra");
        }

        if(other.gameObject.CompareTag("Patos_lentos"))
        {
            Patillo.SendMessage("Patos_lentos"); 
        }
    }   
}
