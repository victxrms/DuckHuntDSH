using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntos : MonoBehaviour
{
    // Declaramos las variables necesarias para utilizarlo
    public Text puntuacion_juego;
    public Text puntuacion_final;
    int puntos, ceros;
    string cadenaceros;

    //Funcion para sumar puntos 
    void Sumar_puntos()
    {
        int.TryParse(puntuacion_juego.text, out puntos);    // Cogemos el valor actual de la puntuacion
        puntos +=200;                                       // Le sumamos 200
        ceros = 10 - puntos.ToString().Length;              // Calculamos la cantidad de ceros que tiene que tener la cadena a traves del tamaño del entero
        cadenaceros = "0".PadLeft(ceros, '0');              //creamos una cadena con el mismo numero de 0's que la cantidad de ceros que tiena
        puntuacion_juego.text = cadenaceros + puntos.ToString();    // Asignamos los puntos al texto del hud principal
        puntuacion_final.text = cadenaceros + puntos.ToString();    // Asignamos los puntos al texto del hud final
    }

    void Puntos_extra()
    {
        int.TryParse(puntuacion_juego.text, out puntos);            // Aqui se hace lo mismo que en la funcion de arriba solo
        puntos +=300;                                               // que se le suma 300 en vez de 200 y se llama cuando se le da
        ceros = 10 - puntos.ToString().Length;                      // a una diana
        cadenaceros = "0".PadLeft(ceros, '0');
        puntuacion_juego.text = cadenaceros + puntos.ToString();
        puntuacion_final.text = cadenaceros + puntos.ToString();
    }
}
