using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_inicial : MonoBehaviour
{
    // Declaramos las variables
    public Text volumen;
    bool activo = true;

    // Funcion que hace que cargue la escena "Facil"
    public void Jugar_normal()
    {
        SceneManager.LoadScene("Facil");
    }

    // Funcion que hace que cargue la escena "Dificil"
    public void Jugar_dificil()
    {
        SceneManager.LoadScene("Dificil");
    }

    // Funcion que hace que se termine el juego
    public void Salir()
    {
        Debug.Log("Saliendo....");
        Application.Quit();

    }

    //Funcion que permite silenciar y desilenciar el programa
    public void Silenciar()
    {
        //Mira si el volumen esta activo o no
        if(activo == true)
        {
            // Si esta activo cambia el texto de si a no y desactiva el volumen
            volumen.text = "no";       
            AudioListener.volume = 0f; 
            activo = false; 
        }
        else
        {
            // Si no esta activo cambia el texto de no a si y activa el volumen
            volumen.text = "si";
            AudioListener.volume = 1.0f;
            activo = true;
        }
        
    }

}
