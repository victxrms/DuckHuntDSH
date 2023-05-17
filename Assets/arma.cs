using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class arma : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    public Image balaC;
    public Image NobalaC;
    public Image balaT;
    public Image NobalaT;


    public Image balaCargador1;
    public Image balaCargador2;
    public Image balaCargador3;

    public List<Image> balasCargador; // Lista para las imágenes de las balas del cargador
    public int indiceBalaCargadorActual = 0; // Índice de la bala actual en el cargador

    

    public List<Image> balasTotales
    public int indiceBalaTotalActual = 0;



    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;

            balaCargador1.sprite = NobalaC;

            if (indiceBalaActual < balasTotales.Count)
            {
                balasTotales[indiceBalaActual].sprite = NobalaT;
                indiceBalaActual++;
            }

            tiempoDesdeDisparo = 0f;
        }
    }
}