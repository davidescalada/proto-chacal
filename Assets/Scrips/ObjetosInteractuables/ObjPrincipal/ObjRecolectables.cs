using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ObjRecolectables : MonoBehaviour, IInteractable
{
    public ObjetosClaves objetosClaves;
    public ControlTextOFF controlTextOFF;
    public TMP_Text text;

    public void Interact()
    {
        Objetos();
        Eliminar();
    }
   
    public void Objetos()
    {
        controlTextOFF.MostrarTexto(2f);
        if (gameObject.name == "ObjetoFin1") { objetosClaves.ObtuvoObj1(); text.text = "Has obtenido el objeto1";  }
        else if (gameObject.name == "ObjetoFin2") { objetosClaves.ObtuvoObj2(); text.text = "Has obtenido el objeto2"; }
        else if (gameObject.name == "ObjetoFin3") { objetosClaves.ObtuvoObj3(); text.text = "Has obtenido el objeto3"; }
        else if (gameObject.name == "ObjFinal") { objetosClaves.ObtuvoObjFinal(); text.text = "Has obtenido el objeto final"; }
    }
    public void Eliminar()
    {
        Destroy(gameObject);
    }
}
