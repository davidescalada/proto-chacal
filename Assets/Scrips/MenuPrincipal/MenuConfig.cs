using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewBehaviourScript : MonoBehaviour
{
    public void PlayGame(string nombreNivel) 
    {
        SceneManager.LoadScene(nombreNivel);
    }
    
    public void Salir()
    {
        Application.Quit();
        Debug.Log("salio");
    }
}
