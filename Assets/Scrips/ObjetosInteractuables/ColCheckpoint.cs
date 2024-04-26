using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColCheckpoint : MonoBehaviour
{
    public Vector3 checkPosition;
    void Start()
    {
        checkPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            other.GetComponent<StatePlayer>().ActualizarCheckpoint(checkPosition);
        }
    }
}
