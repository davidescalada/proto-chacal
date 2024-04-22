using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicio : MonoBehaviour
{
    [SerializeField] public Animator animator;   
    void Start()
    {

        animator.Play("FadeIn");

    }

}
