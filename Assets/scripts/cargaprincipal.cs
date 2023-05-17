using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cargaprincipal : MonoBehaviour
{
    public GameObject menu;
    public GameObject logo;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Invoke("paso_a_menu", 4.2f);
    }

    void paso_a_menu()
    {
        Cursor.lockState = CursorLockMode.None;
        menu.SetActive(true);
        logo.SetActive(false);
    }
}