using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxPlay : MonoBehaviour
{
    [SerializeField] AudioSource sfx;
    
    public void Play()
    {
        sfx.Play();
    }
}
