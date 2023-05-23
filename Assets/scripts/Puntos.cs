using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntos : MonoBehaviour
{
    public Text puntuacion_juego;
    public Text puntuacion_final;
    int puntos, ceros;
    string cadenaceros;

    void Sumar_puntos()
    {
        int.TryParse(puntuacion_juego.text, out puntos);
        puntos +=200;
        ceros = 10 - puntos.ToString().Length;
        cadenaceros = "0".PadLeft(ceros, '0');
        puntuacion_juego.text = cadenaceros + puntos.ToString();
        puntuacion_final.text = cadenaceros + puntos.ToString();
    }

    void Puntos_extra()
    {
        int.TryParse(puntuacion_juego.text, out puntos);
        puntos +=300;
        ceros = 10 - puntos.ToString().Length;
        cadenaceros = "0".PadLeft(ceros, '0');
        puntuacion_juego.text = cadenaceros + puntos.ToString();
        puntuacion_final.text = cadenaceros + puntos.ToString();
    }
}