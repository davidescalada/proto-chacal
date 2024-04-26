using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosClaves : MonoBehaviour
{
    public bool llave;
    public bool obj1;
    public bool obj2;
    public bool obj3;
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

    public void ObtuvoObj1() { obj1 = true; }
    public void ObtuvoObj2() { obj2 = true; }
    public void ObtuvoObj3() { obj3 = true; }
}

