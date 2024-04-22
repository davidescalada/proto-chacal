using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosClaves : MonoBehaviour
{
    public bool llave;
    // Start is called before the first frame update
    void Start()
    {
        llave = false;
    }

   public void ObtuvoLlave()
    {
        llave = true; 
    }

    public bool GetLlave() { return llave; }
}
