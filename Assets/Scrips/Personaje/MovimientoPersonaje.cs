using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public CharacterController characterController;
    public float velocidad = 15f;
    public float gravedad = -10;
    public Transform enElPiso;
    public float distanciaDelPiso;
    public LayerMask mascaraPiso;
    public bool canMove;

    Vector3 velocidadAbajo;
    bool estaEnElPiso;
    void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (canMove == true)
        {
            Movimiento();
            
        }
    }

    public void Movimiento()
    {
        estaEnElPiso = Physics.CheckSphere(enElPiso.position, distanciaDelPiso, mascaraPiso);
        if (estaEnElPiso && velocidadAbajo.y < 0)
        {
            velocidadAbajo.y = -0.5f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 mover = transform.right * x + transform.forward * z;
        characterController.Move(mover * velocidad * Time.deltaTime);

        velocidadAbajo.y += gravedad * Time.deltaTime;

        characterController.Move(velocidadAbajo * velocidad * Time.deltaTime);
    }
    public void SwitchMove()
    {
        canMove =! canMove;
    }
}
