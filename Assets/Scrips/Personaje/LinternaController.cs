using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinternaController : MonoBehaviour
{
    public Light linterna;
    public float stunDuration = 3f;
    public float lightRange;
    
    void Start()
    {
        
    }


    void Update()
    {
        LinternaState();
        ChequearEnemigo();
    }

    public void LinternaState()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (linterna.enabled == true)
            {
                linterna.enabled = false;
            }
            else if (linterna.enabled == false)
            {
                linterna.enabled=true;
            }
        }
    }

    public void ChequearEnemigo()
    {
        if (linterna.enabled == true)
        {
            // Comprobar si el enemigo está dentro del rango de la luz
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, lightRange);
            foreach (Collider collider in hitColliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    // Obtener componente EnemyController y aturdir al enemigo
                    EnemyController enemyController = collider.GetComponent<EnemyController>();
                    if (enemyController != null)
                    {
                        enemyController.StunEnemy();
                    }
                }
        
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        // Dibujar un gizmo para visualizar el rango de la luz
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lightRange);
    }
}
