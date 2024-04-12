using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinternaController : MonoBehaviour
{
    public Light linterna;

    void Start()
    {
        
    }


    void Update()
    {
        LinternaState();
    }

    public void LinternaState()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (linterna.enabled == true)
            {
                linterna.enabled = false;
            }
            else if (linterna.enabled == false)
            {
                linterna.enabled=true;
            }
        }
    }

}
