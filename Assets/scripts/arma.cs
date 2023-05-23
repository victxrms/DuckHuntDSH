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
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    public Sprite balaC;
    public Sprite NobalaC;
    public Sprite balaT;
    public Sprite NobalaT;

    public List<UnityEngine.UI.Image> balasCargador; // Lista para las im�genes de las balas del cargador
    private int indiceBalaCargadorActual = 0; // �ndice de la bala actual en el cargador

    public List<UnityEngine.UI.Image> balasTotales;
    private int indiceBalaTotalActual = 0;

    public GameObject hudJuegoCanvas;
    public GameObject hudFinalCanvas;

    public GameObject personaje;

    private cameraMovement script;

    public GameObject perroMalo;

    public GameObject maintheme;
    
    public GameObject over;

    public GameObject clear;

    GameObject Spawner;

    void recargaEscopeta()
    {
        if (indiceBalaCargadorActual > 0) 
        {
            balasCargador[indiceBalaCargadorActual - 1].sprite = balaC;

            indiceBalaCargadorActual--;
        }
        
    }

    void Start()
    {
        clear.SetActive(false);
        over.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        hudJuegoCanvas.SetActive(true);
        hudFinalCanvas.SetActive(false);
        perroMalo.SetActive(false);
        Spawner = GameObject.FindWithTag("Spawner");
    }

    void Update()
    {
        
        if (indiceBalaTotalActual < balasTotales.Count)
            {

                if (indiceBalaCargadorActual < balasCargador.Count)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        UnityEngine.Debug.Log(indiceBalaCargadorActual);
                        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;

                        balasCargador[indiceBalaCargadorActual].sprite = NobalaC;
                        indiceBalaCargadorActual++;

                        balasTotales[indiceBalaTotalActual].sprite = NobalaT;
                        indiceBalaTotalActual++;

                        if (indiceBalaCargadorActual >= 0) Invoke("recargaEscopeta", 3.0f);
                    }

                }

                if (Input.GetKeyDown(KeyCode.R))
                {
                    for (int i = indiceBalaCargadorActual; i >= 1; i--)
                    {
                        balasCargador[i].sprite = balaC;
                    }

                    indiceBalaCargadorActual = 0;
                }

            }

            else
            {
                Spawner.SendMessage("TerminarEjecuccion");
            }
    }
}