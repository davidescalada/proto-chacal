using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDeselect : MonoBehaviour
{
    LayerMask mask;
    public float distancia = 1.5f;

    public GameObject textDetect;
    GameObject ultimoObj = null;
    Color colorOriginal = Color.white;
    void Start()
    {
        mask = LayerMask.GetMask("Raycast detect");
        textDetect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Raycast(origen, direccion, out hit, distancia, mascara)

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia, mask))
        {
            Deselect();
            SelectObject(hit.transform);

            //Intenta obtener el componente interactuable

            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            // Si el objeto golpeado es interactuable, y se presiona la tecla E
            if (interactable != null && Input.GetKeyDown(KeyCode.E))
            {
                // Llama al método Interact() del objeto
                interactable.Interact();
            }

            //if (hit.collider.tag == "Objeto interactivo")
            //{
            //    if (Input.GetKeyDown(KeyCode.E))
            //    {
            //        hit.collider.transform.GetComponent<Carta>().Eliminar();
            //    }
            //}
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distancia, Color.red);
        }
        else
        {
            Deselect();
        }
    }

    void SelectObject(Transform transform)
    {
        colorOriginal = transform.GetComponent<MeshRenderer>().material.color;
        transform.GetComponent<MeshRenderer>().material.color = Color.green;
        ultimoObj = transform.gameObject;
    }

    void Deselect()
    {
        if (ultimoObj)
        {
            ultimoObj.GetComponent<Renderer>().material.color = colorOriginal;
            ultimoObj = null;
        }
    }

    private void OnGUI() //funcion de unity para acceder a los elementos de la ui
    {
        if (ultimoObj)
        {
            textDetect.SetActive(true);
        }
        else
        {
            textDetect.SetActive(false);
        }

    }
}
