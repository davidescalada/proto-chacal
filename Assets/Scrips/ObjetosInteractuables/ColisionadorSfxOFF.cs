using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionadorSfxOFF : MonoBehaviour
{
    [SerializeField] GameObject sfx;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            sfx.GetComponent<SfxStop>().Stop();
        }
    }
}
