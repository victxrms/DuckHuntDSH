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
    float tiempoVida = 0.0f, TiempoMuerte;
    int numeroOleadaActual = 0, patosACrear, lado, vertical, cantidad;
    Vector3 posicionSpawnPato;
    private GameObject PatoInstancia;
    public ParticleSystem particulas;
    public GameObject acierto, huida, clear, over, maintheme, perroMalo, hudJuegoCanvas, hudFinalCanvas, personaje, pistola;
    public Text TextoHuida, TextoOleada;
    bool tocado, terminado = false;
    private cameraMovement script;

    void Start()
    {
        cantidad = OleadasPatos.Length;
        ProximaOleada();
    }

    void ProximaOleada()
    {
        numeroOleadaActual++;
        if(numeroOleadaActual > cantidad)
        {
            TerminarEjecuccion();   
        }
        else
        {
            OleadaActual = OleadasPatos[numeroOleadaActual - 1];
            patosACrear = OleadaActual.NumPatos;
            tiempoVida = OleadaActual.TiempoSpawn;
            TextoOleada.text = "Oleada " + numeroOleadaActual;
            SpawnOleada();            
        }
        
    }

    void SpawnOleada()
    {
        if(terminado == false)
        {
            if(patosACrear > 0)
            {
                StartCoroutine(SpawnPatos());
            }
            else
            {
                ProximaOleada();
            }
        }
    }

    IEnumerator SpawnPatos()
    {
        tocado = false;
        System.Random random = new System.Random();
        if(random.Next(1,3) == 1)
        {
            lado = -45;
        }
        else
        {
            lado = 15;
        }
        vertical = random.Next(7, 26);
        posicionSpawnPato = new Vector3(12, vertical, lado);
        PatoInstancia =  Instantiate(OleadaActual.Pato, posicionSpawnPato, Quaternion.identity);
        patosACrear-= 1;
        TiempoMuerte = Time.time + tiempoVida;
        yield return new WaitForSeconds(tiempoVida);
        if(tocado == false)
        {
            StartCoroutine(HuidaPato());
        }
    }

    IEnumerator HuidaPato()
   {
        Destroy(PatoInstancia);
        TextoHuida.gameObject.SetActive(true);        
        huida.SetActive(true);
        yield return new WaitForSeconds(3);
        TextoHuida.gameObject.SetActive(false);
        huida.SetActive(false);
        SpawnOleada();
    }

    IEnumerator Patotocado()
    {
        tocado = true;
        Destroy(PatoInstancia);
        ParticleSystem instanciacion_particulas = Instantiate(particulas, PatoInstancia.transform.position, Quaternion.identity);
        acierto.SetActive(true);
        yield return new WaitForSeconds(TiempoMuerte-Time.time);
        acierto.SetActive(false);
        SpawnOleada();
    }

     IEnumerator finaliza()
    {
        clear.SetActive(false);
        over.SetActive(true);
        perroMalo.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Main menu");
    }

    public void UltimoHUD()
    {
        Destroy(clear.GetComponent<AudioSource>());
        clear.SetActive(false);
        StartCoroutine(finaliza());
    }

    void TerminarEjecuccion()
    {   
        if(PatoInstancia != null)
        {
            Destroy(PatoInstancia);
        }
        terminado = true;
        pistola.SetActive(false);
        clear.SetActive(true);
        maintheme.SetActive(false);
        hudJuegoCanvas.SetActive(false);
        hudFinalCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        script = personaje.GetComponent<cameraMovement>();
        script.para();
    }
}