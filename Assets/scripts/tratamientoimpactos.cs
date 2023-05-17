using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tratamientoimpactos : MonoBehaviour
{

    Image barravida;
    float vidarestante;

    public delegate void OnDeath();
    public static event OnDeath OnDeathEnemigo;

    public void HeSidoTocado()
    {
        Debug.Log("enemigo-> me han dado");
        barravida = this.transform.GetChild(2).GetChild(0).GetComponent<Image>();
        vidarestante = GetComponent<gestordevidas>().Vida / GetComponent<gestordevidas>().maxVida;
        barravida.transform.localScale = new Vector3(vidarestante, 1, 1);
    }

    public void EstoyMuerto()
    {
        Debug.Log("enemigo-> estoy muerto");
        
        if (OnDeathEnemigo != null) //lazo el evento de estar muerto
        {
            OnDeathEnemigo();
        }
        Destroy(gameObject);
    }
}
