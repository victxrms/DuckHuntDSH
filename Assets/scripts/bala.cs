using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public float life = 3; // Tiempo de vida de la bala

    GameObject Pato, Diana, Spawner; // Referencias a los objetos del juego

    void Start()
    {
        Pato = GameObject.FindWithTag("Pato"); // Encuentra el objeto con la etiqueta "Pato" y guarda una referencia a él
        Spawner = GameObject.FindWithTag("Spawner"); // Encuentra el objeto con la etiqueta "Spawner" y guarda una referencia a él
    }

    void Awake()
    {
        // Apuntar la bala hacia adelante
        transform.rotation = Quaternion.LookRotation(transform.forward); // Establece la rotación de la bala hacia adelante
        Destroy(gameObject, life); // Destruye la bala después de un tiempo determinado (vida)
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject); // Destruye la bala

        if (other.CompareTag("Pato"))
        {
            Spawner.SendMessage("Patotocado"); // Envía un mensaje al objeto Spawner para indicar que el pato fue tocado
            Spawner.SendMessage("Sumar_puntos"); // Envía un mensaje al objeto Spawner para sumar puntos
        }

        if (other.CompareTag("Puntos_extra"))
        {
            Destroy(other.gameObject); // Destruye el objeto con el que colisionó la bala
            Spawner.SendMessage("Puntos_extra"); // Envía un mensaje al objeto Spawner para obtener puntos extra
        }

        if (other.CompareTag("Patos_lentos"))
        {
            Destroy(other.gameObject); // Destruye el objeto con el que colisionó la bala
            Pato.SendMessage("Patos_lentos"); // Envía un mensaje al objeto Pato para ralentizar los patos
        }
    }
}
