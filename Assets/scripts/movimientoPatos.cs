using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoPatos : MonoBehaviour
{
    //Abajo izquierda-> (16,-5,70)
    //Abajo derecha-> (16,-5, 6)
    //Arriba izquierda-> (16,20,70)
    //Arriba derecha-> (16,20, 6)
   public GameObject Patos;
    
    void Start()
    {
        int max_vert = 20;
        int min_vert = -5;
        int max_hori = 70;
        int min_hori = 6;
    }

    void llamadaPatos()
    {

    }
}
