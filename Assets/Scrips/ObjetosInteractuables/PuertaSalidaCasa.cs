using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuertaSalidaCasa : MonoBehaviour, IInteractable
{
    [SerializeField]Animation abrirPuerta;
    [SerializeField] GameObject textNoLlave;
    [SerializeField] ObjetosClaves objetosClaves;
    [SerializeField] ControlTextOFF controlTextOff;
    public void Interact()
    {
        if (!objetosClaves.GetLlave())
        {
            CondicionSalir();
        }
    }

    public void CondicionSalir()
    {
        if (objetosClaves.GetLlave() == true)
        {
            abrirPuerta.Play("AbrirPuertaSalidaCasa");
        }
        else
        {
            controlTextOff.MostrarTexto(2f);
            textNoLlave.SetActive(true);
            
        }
    }

}
