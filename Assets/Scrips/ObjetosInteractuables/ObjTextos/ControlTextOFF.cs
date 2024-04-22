using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTextOFF : MonoBehaviour
{
    public GameObject text;

    public void MostrarTextoLlave(float duracion)
    {
        text.SetActive(true);
        StartCoroutine(MostrarTextoLlaveCoroutine(duracion));
    }

    private IEnumerator MostrarTextoLlaveCoroutine(float duracion)
    {
      
        yield return new WaitForSeconds(duracion);

        // Desactivar el texto de la llave después de la duración especificada
        text.SetActive(false);
    }
}


