using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Stamina : MonoBehaviour
{
    public Image barraStamina;
    public float stamina;
    public float maxStamina;
 
    void Start()
    {
        UpdateStaminaUI();
    }

    void UpdateStaminaUI()
    {
        barraStamina.fillAmount = stamina / maxStamina;
    }

    public void ModifyStamina(float amount)
    {
        stamina += amount;
        stamina = Mathf.Clamp(stamina, 0, maxStamina);
        UpdateStaminaUI();
    }
}
