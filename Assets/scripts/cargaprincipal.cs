using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cargaprincipal : MonoBehaviour
{
    //Declaramos dos gameobjects que son el menu principal y el logo principal del juego
    public GameObject menu;
    public GameObject logo;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   // Se desactiva el cursor
        Invoke("paso_a_menu", 4.2f);   //Invocamos cuando deja de sonar la musica a la funcion paso_a_menu 
    }

    void paso_a_menu()
    {
        Cursor.lockState = CursorLockMode.None;     //se activa el cursor
        menu.SetActive(true);   //se activa el menu 
        logo.SetActive(false);  //se desactiva el logo
    }
}