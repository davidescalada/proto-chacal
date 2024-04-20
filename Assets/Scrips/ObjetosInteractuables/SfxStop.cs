using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxStop : MonoBehaviour
{
    [SerializeField] AudioSource sfx;

    public void Stop()
    {
        sfx.Stop();
    }
}
