using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePlayer : MonoBehaviour
{
    [SerializeField] GameObject death;
    [SerializeField] GameObject objAnimacion;
    [SerializeField] Camera camPlayer;
    Animation aniDeath;
    bool isDeathAnimationPlaying = false;
    public Vector3 checkpoint;
    void Start()
    {
        
        aniDeath= objAnimacion.GetComponent<Animation>();
    }
 
    public void Death()
    {
        
        camPlayer.enabled = false;
        death.SetActive(true);
        objAnimacion.SetActive(true);
        // Verificar si la animaci�n ya se est� reproduciendo para evitar repeticiones
        if (!isDeathAnimationPlaying)
        {
            StartCoroutine(PlayDeathAnimationAfterDelay(3f));
        }
        Reposicionamiento();
    }

    IEnumerator PlayDeathAnimationAfterDelay(float delay)
    {
        
        isDeathAnimationPlaying = true;
        yield return new WaitForSeconds(delay);
        aniDeath.Play("death_fade");
        // Esperar hasta que la animaci�n haya terminado
        yield return new WaitForSeconds(aniDeath.clip.length);
        objAnimacion.SetActive(false); // Desactivar el objeto de la animaci�n despu�s de que termine la animaci�n
        isDeathAnimationPlaying = false;
        
        Resu();
       
    }
    public void Resu()
    {
        camPlayer.enabled = true;
        death.SetActive(false);
    }

    public void Reposicionamiento()
    {
        Debug.Log("Entro en el reposicionamientot?");
        transform.position = checkpoint;
    }

    public void ActualizarCheckpoint(Vector3 position)
    {
        checkpoint = position;
        Debug.Log(checkpoint);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
       {
            Reposicionamiento();
        }
    }
}
