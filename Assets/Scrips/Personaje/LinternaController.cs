using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinternaController : MonoBehaviour
{
    public Light linterna;
    public float stunDuration = 3f;
    public float lightRange;
    public LayerMask maskEnemy;
    public LayerMask maskEnemyVisual;
    void Start()
    {
        maskEnemy = LayerMask.GetMask("EnemyStuneable");
        maskEnemyVisual = LayerMask.GetMask("EnemyVisual");
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

            RaycastHit hit;
            foreach (Collider collider in hitColliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, lightRange, maskEnemy))
                    {
                        // Obtener componente EnemyController y aturdir al enemigo
                        EnemyController enemyController = collider.GetComponent<EnemyController>();

                        if (enemyController != null)
                        {
                            enemyController.StunEnemy();
                        }
                    }

                }
                else if (collider.CompareTag("EnemyVisual"))
                {
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, lightRange, maskEnemyVisual))
                    {
                        EnemyContactVisual enemyVisual = collider.GetComponent<EnemyContactVisual>();
                        if (enemyVisual != null)
                        {
                            enemyVisual.GenerarMareo();
                        }
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
