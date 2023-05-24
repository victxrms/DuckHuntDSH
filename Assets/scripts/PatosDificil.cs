using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PatosDificil : MonoBehaviour
{
    // Abajo izquierda-> (12,7,15)
    // Abajo derecha-> (12, 7, -45)
    // Arriba izquierda-> (12,25,15)
    // Arriba derecha-> (12, 25, -45)

    float max_vert = 25f; // Valor máximo para la coordenada vertical
    float min_vert = 7f; // Valor mínimo para la coordenada vertical
    float max_hori = 15f; // Valor máximo para la coordenada horizontal
    float min_hori = -45f; // Valor mínimo para la coordenada horizontal
    float y; // Posición actual en el eje Y
    float z; // Posición actual en el eje Z
    float velocidad_y; // Velocidad de movimiento en el eje Y
    float velocidad_z; // Velocidad de movimiento en el eje Z
    int mov_vert; // Dirección de movimiento vertical (1: hacia arriba, 2: hacia abajo)
    int mov_hor; // Dirección de movimiento horizontal (1: hacia la derecha, 2: hacia la izquierda)

    void Start()
    {
        y = transform.position.y; // Obtiene la posición inicial en el eje Y
        z = transform.position.z; // Obtiene la posición inicial en el eje Z
        System.Random random = new System.Random(); // Crea una instancia de la clase Random para generar valores aleatorios
        velocidad_y = (float)random.Next(1, 4) / 30; // Genera una velocidad aleatoria en el eje Y
        velocidad_z = (float)random.Next(1, 4) / 30; // Genera una velocidad aleatoria en el eje Z
        mov_vert = random.Next(1, 3); // Genera una dirección de movimiento vertical aleatoria
        mov_hor = random.Next(1, 3); // Genera una dirección de movimiento horizontal aleatoria
    }

    void Update()
    {
        if (y >= max_vert)
        {
            mov_vert = 2; // Si la posición en el eje Y alcanza el valor máximo, cambia la dirección de movimiento vertical a hacia abajo
        }

        if (y <= min_vert)
        {
            mov_vert = 1; // Si la posición en el eje Y alcanza el valor mínimo, cambia la dirección de movimiento vertical a hacia arriba
        }

        if (z >= max_hori)
        {
            mov_hor = 2; // Si la posición en el eje Z alcanza el valor máximo, cambia la dirección de movimiento horizontal a hacia la izquierda
        }

        if (z <= min_hori)
        {
            mov_hor = 1; // Si la posición en el eje Z alcanza el valor mínimo, cambia la dirección de movimiento horizontal a hacia la derecha
        }

        if (mov_vert == 1)
        {
            if (mov_hor == 1)
            {
                y += velocidad_y; // Incrementa la posición en el eje Y según la velocidad actual
                z += velocidad_z; // Incrementa la posición en el eje Z según la velocidad actual
                transform.position = new Vector3(12, y, z); // Actualiza la posición del objeto en base a las nuevas coordenadas
            }
            else
            {
                y += velocidad_y; // Incrementa la posición en el eje Y según la velocidad actual
                z -= velocidad_z; // Decrementa la posición en el eje Z según la velocidad actual
                transform.position = new Vector3(12, y, z); // Actualiza la posición del objeto en base a las nuevas coordenadas
            }
        }
        else
        {
            if (mov_hor == 1)
            {
                y -= velocidad_y; // Decrementa la posición en el eje Y según la velocidad actual
                z += velocidad_z; // Incrementa la posición en el eje Z según la velocidad actual
                transform.position = new Vector3(12, y, z); // Actualiza la posición del objeto en base a las nuevas coordenadas
            }
            else
            {
                y -= velocidad_y; // Decrementa la posición en el eje Y según la velocidad actual
                z -= velocidad_z; // Decrementa la posición en el eje Z según la velocidad actual
                transform.position = new Vector3(12, y, z); // Actualiza la posición del objeto en base a las nuevas coordenadas
            }
        }
    }

    void Patos_lentos()
    {
        velocidad_y /= 2; // Reduce a la mitad la velocidad en el eje Y
        velocidad_z /= 2; // Reduce a la mitad la velocidad en el eje Z
        Invoke("Patos_normales", 3f); // Llama al método "Patos_normales" después de 3 segundos
    }

    void Patos_normales()
    {
        velocidad_y *= 2; // Duplica la velocidad en el eje Y
        velocidad_z *= 2; // Duplica la velocidad en el eje Z
    }
}
