using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oleada : MonoBehaviour
{
    /*
    public ValoresPatos[] OleadasPatos;
    private ValoresPatos OleadaActual;
    float tiempoEspera = 0.0f;
    int numeroOrdaActual = 0; //Para ir recorriendo el array de los enemigos
    int enemigosACrear = 0;
    int enemigosporMatar = 0;

    // Start is called before the first frame update
    void Start()
    {
        NextOrda(); //Cuando empieza el juego creamos una orda
        //tratamientoImpactos.OnDeathEnemigo += muertoEnemigo;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemigosACrear > 0 && Time.time > tiempoEspera)
        {
            GameObject enemigoNuevo = Instantiate(ordaActual.tipoenemigo, Vector3.zero, Quaternion.identity);
            this.enemigosACrear--; //reducimos el número de enemigos a crear
            tiempoEspera = Time.time + ordaActual.tiempoEnemigos;  //ponemos el contador al tiempo actual para la creación
        }
        
    }
    void NextOrda()
    {
        numeroOrdaActual++;
        //ordaActual = ordaEnemigos[numeroOrdaActual - 1]; //cojo el primer enemigo
        //enemigosACrear = ordaActual.numEnemigos;
        //enemigosporMatar = ordaActual.numEnemigos;

    }

    void muertoEnemigo()
    {
        enemigosporMatar--;
        if (enemigosporMatar == 0)
        {
            NextOrda();
        }
    }
    */
}