using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class arma : MonoBehaviour
{
    public Transform bulletSpawnPoint; // Punto de aparición de las balas
    public GameObject bulletPrefab; // Prefabricado de la bala
    public float bulletSpeed = 10; // Velocidad de la bala

    public Sprite balaC; // Sprite de bala cargada
    public Sprite NobalaC; // Sprite de bala no cargada
    public Sprite balaT; // Sprite de bala total
    public Sprite NobalaT; // Sprite de bala no total

    public List<UnityEngine.UI.Image> balasCargador; // Lista de imágenes para las balas en el cargador
    private int indiceBalaCargadorActual = 0; // Índice de la bala actual en el cargador

        public List<UnityEngine.UI.Image> balasTotales; // Lista de imágenes para las balas totales
    private int indiceBalaTotalActual = 0; // Índice de la bala actual en el inventario

    public GameObject hudJuegoCanvas; // Objeto del canvas del HUD del juego
    public GameObject hudFinalCanvas; // Objeto del canvas final del HUD

    public GameObject personaje; // Objeto del personaje

    private cameraMovement script; // Referencia al script de movimiento de la cámara

    public GameObject perroMalo; // Objeto del perro malo

    public GameObject maintheme; // Objeto del tema principal

    public GameObject over; // Objeto de "Game Over"

    public GameObject clear; // Objeto de "Nivel Completado"

    GameObject Spawner; // Objeto del generador de enemigos

    void recargaEscopeta()
    {
        if (indiceBalaCargadorActual > 0) 
        {
            balasCargador[indiceBalaCargadorActual - 1].sprite = balaC; // Cambiar el sprite de la última bala disparada en el cargador a "balaC"

            indiceBalaCargadorActual--; // Decrementar el índice de la bala actual en el cargador
        }
    }


        void Start()
    {
        clear.SetActive(false); // Desactivar el objeto "Nivel Completado"
        over.SetActive(false); // Desactivar el objeto "Game Over"
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor en el centro de la pantalla
        hudJuegoCanvas.SetActive(true); // Activar el canvas del HUD del juego
        hudFinalCanvas.SetActive(false); // Desactivar el canvas final del HUD
        perroMalo.SetActive(false); // Desactivar el objeto del perro malo
        Spawner = GameObject.FindWithTag("Spawner"); // Encontrar el objeto con la etiqueta "Spawner" y asignarlo a la variable "Spawner"
    }


        void Update()
    {
        if (indiceBalaTotalActual < balasTotales.Count)
        {
            if (indiceBalaCargadorActual < balasCargador.Count)
            {
                if (Input.GetMouseButtonDown(0)) // Si se presiona el botón izquierdo del ratón
                {
                    UnityEngine.Debug.Log(indiceBalaCargadorActual); // Mostrar el índice de la bala actual en el cargador en la consola de Unity

                    var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation); // Instanciar una nueva bala en la posición y rotación del punto de aparición de las balas
                    bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed; // Aplicar una velocidad a la bala hacia adelante

                    balasCargador[indiceBalaCargadorActual].sprite = NobalaC; // Cambiar el sprite de la bala actual en el cargador a "NobalaC"
                    indiceBalaCargadorActual++; // Incrementar el índice de la bala actual en el cargador

                    balasTotales[indiceBalaTotalActual].sprite = NobalaT; // Cambiar el sprite de la bala actual en el inventario a "NobalaT"
                    indiceBalaTotalActual++; // Incrementar el índice de la bala actual en el inventario

                    if (indiceBalaCargadorActual >= 0) Invoke("recargaEscopeta", 3.0f); // Si el índice de la bala actual en el cargador es mayor o igual a cero, invocar el método "recargaEscopeta()" después de 3 segundos
                }
            }

            if (Input.GetKeyDown(KeyCode.R)) // Si se presiona la tecla "R"
            {
                recargaEscopeta(); // Llamar al método "recargaEscopeta()" para recargar una bala en el cargador
            }
        }
        else
        {
            Spawner.SendMessage("TerminarEjecuccion"); // Si no hay más balas disponibles en el inventario, enviar
        }
    }
}