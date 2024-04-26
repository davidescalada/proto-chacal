using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraDeath : MonoBehaviour
{
    public float velocidad = 100f;
    float rotacionX = 0f;
    float rotacionY = 0f;
    [SerializeField] Light luz;
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * velocidad * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * velocidad * Time.deltaTime;

        rotacionX -= mouseY;
        rotacionY += mouseX;
        rotacionX = Mathf.Clamp(rotacionX, 60f, 110f);
        
        transform.localRotation = Quaternion.Euler(rotacionX, rotacionY, 0f);
        luz.transform.localRotation = Quaternion.Euler(rotacionX, rotacionY, 0f);
        
    }
}
