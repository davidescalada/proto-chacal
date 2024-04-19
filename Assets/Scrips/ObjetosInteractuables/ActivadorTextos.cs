using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorTextos : MonoBehaviour
{
    public GameObject notaVisual;
    public GameObject objVisual;
    public GameObject camVisual;
    public GameObject objEnEscena;
    public GameObject player; 
    public bool activa;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && activa == true)
        {
            player.GetComponent<MovimientoPersonaje>().SwitchMove();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            TextOn();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && activa == true)
        {
            player.GetComponent<MovimientoPersonaje>().SwitchMove();
            OcultarMouse();
            TextOff();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            activa = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            TextOff();
            activa = false;
            
        }
    }
    public void TextOn()
    {
        notaVisual.SetActive(true);
        camVisual.SetActive(true);
        objVisual.SetActive(true);
        objEnEscena.SetActive(false);
    }

    public void TextOff()
    {
        notaVisual.SetActive(false);
        camVisual.SetActive(false);
        objVisual.SetActive(false);
        objEnEscena.SetActive(true);
    }

    public void OcultarMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
