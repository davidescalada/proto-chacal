using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MesaIglesia : MonoBehaviour
{
    [SerializeField] GameObject uiText;
    public TMP_Text todos;
    public TMP_Text faltan;
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            if (other.GetComponent<ObjetosClaves>().obj1 == true && other.GetComponent<ObjetosClaves>().obj2 == true && other.GetComponent<ObjetosClaves>().obj3 == true)
            {
                todos.text = "Tienes todos los objetos";
                //Debug.Log("Tienes todos los objetos");
            }
            else
            {
                faltan.text = "Aún te faltan objetos";
                //Debug.Log("Aun te faltan objetos");
            }
            uiText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            uiText.SetActive(false);
        }
    }
}
