using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class EnemyContactVisual : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachine;
    private CinemachineBasicMultiChannelPerlin noise;
    private float value = 1f;
    private float valueInitial;
    private void Start()
    {
        noise = cinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        valueInitial = noise.m_FrequencyGain;
    }
    public void GenerarMareo()
    {
        if (noise != null)
        {
            noise.m_FrequencyGain += value * Time.deltaTime;
            Debug.Log(noise.m_FrequencyGain);
            if (noise.m_FrequencyGain >= 30)
            {
                noise.m_FrequencyGain = valueInitial;
            }
        }
        
    }
}

