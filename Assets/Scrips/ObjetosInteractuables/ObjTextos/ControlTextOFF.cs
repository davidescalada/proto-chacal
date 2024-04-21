using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTextOFF : MonoBehaviour
{
    public GameObject textLlave;

    public void MostrarTextoLlave(float duracion)
    {
        textLlave.SetActive(true);
        StartCoroutine(MostrarTextoLlaveCoroutine(duracion));
    }

    private IEnumerator MostrarTextoLlaveCoroutine(float duracion)
    {
      
        yield return new WaitForSeconds(duracion);

        // Desactivar el texto de la llave despu�s de la duraci�n especificada
        textLlave.SetActive(false);
    }
}


