using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MesaIglesia : MonoBehaviour, IInteractable
{
  
    public TMP_Text todos;
    public TMP_Text faltan;
    public GameObject objFinal;
    [SerializeField] ObjetosClaves objetosClaves;
    [SerializeField] ControlTextOFF ControlTextOFF;
    private bool objEntregado = false;
    public void Interact()
    {
        CheckObjetos();
    }

    private void CheckObjetos()
    {
        if (!objEntregado)
        {
            if (objetosClaves.obj1 == true && objetosClaves.obj2 == true && objetosClaves.obj3 == true)
            {
                todos.text = "Has obtenido el objeto sagrado que te permitirá ir más allá";
                CrearNuevoObjeto();
            }
            else
            {
                faltan.text = "Aún te faltan objetos";
            }
            ControlTextOFF.MostrarTexto(3f);
        }
            
    }

    private void CrearNuevoObjeto()
    {
        Instantiate(objFinal, transform.position + new Vector3(0, 2f, 0), Quaternion.identity);
        objEntregado = true;
    }
}
