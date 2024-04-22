using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulacionObjeto : MonoBehaviour
{
    float speedH = 1.5f;
    float speedV = 1.5f;

    float movH;
    float movV;

    private void OnMouseDrag()
    {
        movH -= speedH * Input.GetAxis("Mouse X");
        movV += speedV * Input.GetAxis("Mouse Y");
        
        if (Input.GetMouseButton(0))
        {
            transform.eulerAngles = new Vector3(movV, movH, 0f);
        }
            
    }
   
    
}
