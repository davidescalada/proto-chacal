using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasma1Play : MonoBehaviour
{
    [SerializeField] Animation walk;
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            walk.Play("Fantasma1Caminar");
        }
    }

    public void Delete()
    {
        Destroy(this.gameObject);
    }
}
