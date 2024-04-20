using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibracion : MonoBehaviour
{
    public GameObject puerta;
    string tagName = "PuertaVibracion";
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            puerta = GameObject.FindGameObjectWithTag(tagName);
            puerta.GetComponent<Animation>().Play("vibracion");
        }
    }
}
