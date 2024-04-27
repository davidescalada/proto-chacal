using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public CharacterController characterController;
    public float velocidad;
    public float gravedad = -10;
    public Transform enElPiso;
    public float distanciaDelPiso;
    public LayerMask mascaraPiso;
    public bool canMove;
    private float stamina;
    private bool pressRun;
    Vector3 velocidadAbajo;
    bool estaEnElPiso;
    void Start()
    {
        stamina = 10;
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

        if (Input.GetKey(KeyCode.LeftShift))
        {
            pressRun = true;
            if (stamina > 0)
            {
                stamina = stamina - 0.1f * Time.deltaTime;
                velocidad = 4;
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            velocidad = 2;      
            pressRun = false;
        }

        if (stamina < 10 && !pressRun)
        {
            stamina = stamina + 0.5f * Time.deltaTime;
        }
        Debug.Log(stamina);
       



        characterController.Move(velocidadAbajo * velocidad * Time.deltaTime);
    }
    public void SwitchMove()
    {
        canMove =! canMove;
    }
}
