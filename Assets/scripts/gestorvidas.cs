using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class gestordevidas : MonoBehaviour
{
    public float Vida = 5.0f;
    public float maxVida = 5.0f;

    public UnityEvent HeSidoTocado;
    public UnityEvent EstoyMuerto;

    void tocado(float fuerza)
    {
        Debug.Log("Enemigo-> me ha dado!!!!!!");
        //accion de que me han dado
        HeSidoTocado.Invoke();
        Vida -= fuerza;
        if(Vida==0)
        {
            //accion de haberme muerto
            EstoyMuerto.Invoke();
        }
    }
}

