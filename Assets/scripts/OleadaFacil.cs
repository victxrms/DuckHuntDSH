using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class OleadaFacil : MonoBehaviour
{
    public ValoresPatos[] OleadasPatos;
    private ValoresPatos OleadaActual;
    float tiempoVida = 0.0f;
    int numeroOleadaActual = 0, patosACrear, lado, vertical, cantidad;
    Vector3 posicionSpawnPato;
    GameObject Pato_nuevo;
    public ParticleSystem particulas;
    public GameObject acierto, huida;
    public Text texto;

    void Start()
    {
        ProximaOleada(); //Cuando empieza el juego creamos una oleada
    }

    void ProximaOleada()
    {
        numeroOleadaActual++;
        OleadaActual = OleadasPatos[numeroOleadaActual - 1];
        patosACrear = OleadaActual.NumPatos;
        tiempoVida = OleadaActual.TiempoSpawn;
        cantidad = OleadasPatos.Length;
        if(numeroOleadaActual > cantidad)
        {
            SceneManager.LoadScene("Main menu");
        }
        else
        {
        SpawnOleada();            
        }
    }

    void SpawnOleada()
    {
        if(patosACrear > 0)
        {
            SpawnPatos();
        }
        else
        {
            ProximaOleada();
        }
    }

    void SpawnPatos()
    {
        System.Random random = new System.Random();
        if(random.Next(1,3)==1)
        {
            lado = -15;
        }
        else
        {
            lado = 45;
        }
        vertical = random.Next(-3, 16);
        posicionSpawnPato = new Vector3(17, lado, vertical);
        Pato_nuevo =  Instantiate(OleadaActual.Patos, posicionSpawnPato, Quaternion.identity);
        patosACrear-= 1;
        Invoke("HuidaPato", tiempoVida);
    }

    void HuidaPato()
    {
        Destroy(Pato_nuevo);
        texto.gameObject.SetActive(true);        
        huida.SetActive(true);
        Thread.Sleep(2000);
        texto.gameObject.SetActive(false);
        huida.SetActive(false);
        SpawnOleada();
    }

    void Patotocado()
    {
        CancelInvoke("HuidaPato");
        Destroy(Pato_nuevo);
        ParticleSystem instanciacion_particulas = Instantiate(particulas, Pato_nuevo.transform.position, Quaternion.identity);
        acierto.SetActive(true);
        Thread.Sleep(2000);
        acierto.SetActive(false);
        SpawnOleada();
    }
}