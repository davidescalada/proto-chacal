using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Llave : MonoBehaviour, IInteractable
{
    public UnityEvent onInteract;
    public ControlTextOFF controlTextOFF;
    private bool interacted = false;
    public void Interact()
    {
        if (!interacted)
        {
            interacted = true;
            onInteract.Invoke();
            controlTextOFF.MostrarTextoLlave(4.0f);
            gameObject.SetActive(false);
        } 
    }

    public void Eliminar()
    {
        Destroy(this.gameObject);  
    }
}
