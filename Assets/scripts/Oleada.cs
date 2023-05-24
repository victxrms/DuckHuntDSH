using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class Oleada : MonoBehaviour
{
    public ValoresPatos[] OleadasPatos; // Array de objetos ValoresPatos que representa las oleadas de patos
    private ValoresPatos OleadaActual; // Objeto ValoresPatos que representa la oleada actual
    float tiempoVida = 0.0f, TiempoMuerte; // Duración de vida de los patos y tiempo de muerte del pato
    int numeroOleadaActual = 0, patosACrear, lado, vertical, cantidad; // Número de la oleada actual, cantidad de patos a crear, coordenadas de posición y cantidad total de oleadas
    Vector3 posicionSpawnPato; // Posición de spawn del pato
    private GameObject PatoInstancia; // Instancia del pato
    public ParticleSystem particulas; // Sistema de partículas para los efectos
    public GameObject acierto, huida, clear, over, maintheme, perroMalo, hudJuegoCanvas, hudFinalCanvas, personaje, pistola; // Objetos del juego
    public Text TextoHuida, TextoOleada; // Texto para mostrar la información de la huida y la oleada actual
    bool tocado, terminado = false; // Variables de control
    private cameraMovement script; // Referencia al script de movimiento de la cámara

    void Start()
    {
        cantidad = OleadasPatos.Length; // Asigna la longitud del array de oleadas a la variable "cantidad"
        ProximaOleada(); // Inicia la primera oleada
    }

    void ProximaOleada()
    {
        numeroOleadaActual++; // Incrementa el número de la oleada actual

        if(numeroOleadaActual > cantidad)
        {
            TerminarEjecuccion(); // Si se han completado todas las oleadas, termina la ejecución del juego  
        }
        else
        {
            OleadaActual = OleadasPatos[numeroOleadaActual - 1]; // Obtiene la oleada actual del array de oleadas
            patosACrear = OleadaActual.NumPatos; // Obtiene la cantidad de patos a crear de la oleada actual
            tiempoVida = OleadaActual.TiempoSpawn; // Obtiene el tiempo de vida de los patos de la oleada actual
            TextoOleada.text = "Oleada " + numeroOleadaActual; // Muestra el texto de la oleada actual en el HUD
            SpawnOleada(); // Inicia la creación de los patos de la oleada actual
        }
    }

    void SpawnOleada()
    {
        if(terminado == false)
        {
            if(patosACrear > 0)
            {
                StartCoroutine(SpawnPatos()); // Inicia la corrutina para crear los patos de la oleada actual
            }
            else
            {
                ProximaOleada(); // Si se han creado todos los patos de la oleada actual, pasa a la siguiente oleada
            }
        }
    }

    IEnumerator SpawnPatos()
    {
        tocado = false; // Reinicia la variable de control "tocado"
        System.Random random = new System.Random(); // Crea una instancia de la clase Random para generar valores aleatorios

        if(random.Next(1,3) == 1)
        {
            lado = -45; // Asigna el valor de -45 a la variable "lado"
        }
        else
        {
            lado = 15; // Asigna el valor de 15 a la variable "lado"
        }

        vertical = random.Next(7, 26); // Genera un valor aleatorio entre 7 y 26 para la variable "vertical"
        posicionSpawnPato = new Vector3(12, vertical, lado); // Crea un nuevo vector de posición para el spawn del pato
        PatoInstancia =  Instantiate(OleadaActual.Pato, posicionSpawnPato, Quaternion.identity); // Instancia un nuevo pato en la posición de spawn
        patosACrear-= 1; // Reduce la cantidad de patos a crear

        TiempoMuerte = Time.time + tiempoVida; // Calcula el tiempo de muerte del pato

        yield return new WaitForSeconds(tiempoVida); // Espera durante el tiempo de vida del pato

        if(tocado == false)
        {
            StartCoroutine(HuidaPato()); // Si el pato no ha sido tocado, inicia la corrutina de huida del pato
        }
    }

    IEnumerator HuidaPato()
   {
        Destroy(PatoInstancia); // Destruye el pato
        TextoHuida.gameObject.SetActive(true); // Activa el texto de huida en el HUD
        huida.SetActive(true); // Activa el objeto de huida
        yield return new WaitForSeconds(3); // Espera durante 3 segundos
        TextoHuida.gameObject.SetActive(false); // Desactiva el texto de huida en el HUD
        huida.SetActive(false); // Desactiva el objeto de huida
        SpawnOleada(); // Inicia la siguiente oleada
    }

    IEnumerator Patotocado()
    {
        tocado = true; // Establece la variable "tocado" a verdadero
        Destroy(PatoInstancia); // Destruye el pato
        ParticleSystem instanciacion_particulas = Instantiate(particulas, PatoInstancia.transform.position, Quaternion.identity); // Instancia un sistema de partículas en la posición del pato
        acierto.SetActive(true); // Activa el objeto de acierto
        yield return new WaitForSeconds(TiempoMuerte-Time.time); // Espera hasta que el tiempo de muerte del pato haya transcurrido
        acierto.SetActive(false); // Desactiva el objeto de acierto
        SpawnOleada(); // Inicia la siguiente oleada
    }

     IEnumerator finaliza()
    {
        clear.SetActive(false); // Desactiva el objeto de "Nivel Completado"
        over.SetActive(true); // Activa el objeto de "Game Over"
        perroMalo.SetActive(true); // Activa el objeto del perro malo
        yield return new WaitForSeconds(5); // Espera durante 5 segundos
        SceneManager.LoadScene("Main menu"); // Carga la escena del menú principal
    }

    public void UltimoHUD()
    {
        Destroy(clear.GetComponent<AudioSource>()); // Destruye el componente de audio del objeto "Nivel Completado"
        clear.SetActive(false); // Desactiva el objeto de "Nivel Completado"
        StartCoroutine(finaliza()); // Inicia la corrutina de finalización del juego
    }

    void TerminarEjecuccion()
    {   
        if(PatoInstancia != null)
        {
            Destroy(PatoInstancia); // Destruye el pato
        }
        
        terminado = true; // Establece la variable "terminado" a verdadero
        pistola.SetActive(false); // Desactiva el objeto de la pistola
        clear.SetActive(true); // Activa el objeto de "Nivel Completado"
        maintheme.SetActive(false); // Desactiva la música de fondo principal
        hudJuegoCanvas.SetActive(false); // Desactiva el HUD del juego
        hudFinalCanvas.SetActive(true); // Activa el HUD final
        Cursor.lockState = CursorLockMode.None; // Desbloquea el cursor del ratón
        script = personaje.GetComponent<cameraMovement>(); // Obtiene el componente cameraMovement del personaje
        script.para(); // Llama al método "para()" del script de movimiento de la cámara
    }
}
