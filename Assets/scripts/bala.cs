using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
<<<<<<< HEAD
    // Declaramos variables
    public float life = 3;
    GameObject Pato, Spawner;

    void Start()
    {
        // Cogemos los gameobjects a lo que le vamos a enviar mensajes
        Pato = GameObject.FindWithTag("Pato");      
        Spawner = GameObject.FindWithTag("Spawner");
=======
    public float life = 3; // Tiempo de vida de la bala

    GameObject Pato, Diana, Spawner; // Referencias a los objetos del juego

    void Start()
    {
        Pato = GameObject.FindWithTag("Pato"); // Encuentra el objeto con la etiqueta "Pato" y guarda una referencia a él
        Spawner = GameObject.FindWithTag("Spawner"); // Encuentra el objeto con la etiqueta "Spawner" y guarda una referencia a él
>>>>>>> 8672368c2526311283ff2b64f4d327f6e5954d86
    }

    void Awake()
    {
        // Apuntar la bala hacia adelante
        transform.rotation = Quaternion.LookRotation(transform.forward); // Establece la rotación de la bala hacia adelante
        Destroy(gameObject, life); // Destruye la bala después de un tiempo determinado (vida)
    }

    void OnTriggerEnter(Collider other)
    {
<<<<<<< HEAD
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
=======
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
>>>>>>> 8672368c2526311283ff2b64f4d327f6e5954d86
        }
    }
}
