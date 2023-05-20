using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Patos : MonoBehaviour
{
    //Abajo izquierda-> (16,-5,70)
    //Abajo derecha-> (16,-5, 6)
    //Arriba izquierda-> (16,20,70)
    //Arriba derecha-> (16,20, 6)

    float max_vert = 20f;
    float min_vert = -5f;
    float max_hori = 70f;
    float min_hori = 6f;
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
                transform.position = new Vector3(16, y, z);
            }
            else
            {
                y += velocidad_y;
                z -=velocidad_z;
                transform.position = new Vector3(16, y, z);
            }
        }
        else
        {
            if(mov_hor == 1)
            {
                y -= velocidad_y;
                z +=velocidad_z;
                transform.position = new Vector3(16, y, z);
            }
            else
            {
                y -= velocidad_y;
                z -=velocidad_z;
                transform.position = new Vector3(16, y, z);
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
