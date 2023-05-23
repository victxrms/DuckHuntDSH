using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PatosDificil : MonoBehaviour
{
    //Abajo izquierda-> (12,7,15)
    //Abajo derecha-> (12, 7, -45)
    //Arriba izquierda-> (12,25,15)
    //Arriba derecha-> (12, 25, -45)

    float max_vert = 25f;
    float min_vert = 7f;
    float max_hori = 15f;
    float min_hori = -45f;
    float y;
    float z;
    float velocidad_y;
    float velocidad_z;
    int mov_vert;
    int mov_hor;

    void Start()
    {
        y = transform.position.y;
        z = transform.position.z;
        System.Random random = new System.Random();
        velocidad_y = (float)random.Next(1, 7)/30;
        velocidad_z  = (float)random.Next(1, 7)/30;
        mov_vert = random.Next(1, 3);
        mov_hor = random.Next(1, 3);
    }

    void Update()
    {
        if(y >= max_vert)
        {
            mov_vert = 2;
        }

        if(y <= min_vert)
        {
            mov_vert = 1;
        }

        if(z >= max_hori)
        {
            mov_hor = 2;
        }

        if(z <= min_hori)
        {
            mov_hor = 1;
        }

        if(mov_vert == 1)
        {
            if(mov_hor == 1)
            {
                y += velocidad_y;
                z +=velocidad_z;
                transform.position = new Vector3(12, y, z);
            }
            else
            {
                y += velocidad_y;
                z -=velocidad_z;
                transform.position = new Vector3(12, y, z);
            }
        }
        else
        {
            if(mov_hor == 1)
            {
                y -= velocidad_y;
                z +=velocidad_z;
                transform.position = new Vector3(12, y, z);
            }
            else
            {
                y -= velocidad_y;
                z -=velocidad_z;
                transform.position = new Vector3(12, y, z);
            }
        }
    }        

    void Patos_lentos()
    {
        velocidad_y /= 2;
        velocidad_z /= 2;
        Invoke("Patos_normales", 3f);
    }

    void Patos_normales()
    {
        velocidad_y *= 2;
        velocidad_z *= 2;
    }
}
