using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_inicial : MonoBehaviour
{
    public Text volumen;
    bool activo = true;

    public void Jugar_normal()
    {
        SceneManager.LoadScene("Facil");
    }

    public void Jugar_dificil()
    {
        SceneManager.LoadScene("Dificil");
    }

    public void Salir()
    {
        Debug.Log("Saliendo....");
        Application.Quit();

    }

    public void Silenciar()
    {
        if(activo == true)
        {
            volumen.text = "no";       
            AudioListener.volume = 0f; 
            activo = false; 
        }
        else
        {
            volumen.text = "si";
            AudioListener.volume = 1.0f;
            activo = true;
        }
        
    }

}
