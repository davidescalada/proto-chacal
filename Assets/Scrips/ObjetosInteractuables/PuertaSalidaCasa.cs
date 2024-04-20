using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaSalidaCasa : MonoBehaviour
{
    [SerializeField]Animation abrirPuerta;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        { 
            if (other.GetComponent<ObjetosClaves>().GetLlave() == true)
            {
                abrirPuerta.Play("AbrirPuertaSalidaCasa");
            }
            else { Debug.Log("no tenes la llave"); }
        }
    }
}
