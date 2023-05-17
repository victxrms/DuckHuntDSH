using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_inicial : MonoBehaviour
{
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
}
