using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePlayer : MonoBehaviour
{
    [SerializeField] GameObject death;
    Animator aniDeath;
    
    void Start()
    {
        aniDeath = death.GetComponent<Animator>();
        
    }

    public void Death()
    {
        this.gameObject.GetComponent<Camera>().enabled = false;
        death.SetActive(true);
        aniDeath.enabled = true;
        aniDeath.Play("death_fade");
    }

    public void Resu()
    {
        this.gameObject.GetComponent<Camera>().enabled = true;
        death.SetActive(false);
        aniDeath.enabled = false;
    }
}
