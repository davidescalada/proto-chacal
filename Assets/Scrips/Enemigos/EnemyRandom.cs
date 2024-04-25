using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public enum EnemyState { Idle, Patrol, Chase }
    public EnemyState currentState = EnemyState.Idle;

    public Transform player;
    public float chaseRange = 10f;
    public float patrolSpeed = 2f;
    public float chaseSpeed = 5f;
    public float patrolTimer = 5f;
    public float idleTimer = 2f;

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private Vector3 patrolDestination;
    private float timer;

    public float stunDuration = 3f;
    private bool isStunned = false;
    private float stunTimer = 0f;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        patrolDestination = GetRandomPoint();
        timer = patrolTimer;
    }

    void Update()
    {
        if (!isStunned)
        {
            switch (currentState)
            {
                case EnemyState.Idle:
                    Idle();
                    break;
                case EnemyState.Patrol:
                    Patrol();
                    break;
                case EnemyState.Chase:
                    Chase();
                    break;
            }
        }
        else
        {
            Stunned();
        }
    }

    void Idle()
    {
        animator.SetBool("Idle", true);
        animator.SetBool("Walk", false);

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            currentState = EnemyState.Patrol;
            timer = patrolTimer;
        }
    }

    void Patrol()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("Walk", true);

        navMeshAgent.speed = patrolSpeed;
        navMeshAgent.SetDestination(patrolDestination);

        if (Vector3.Distance(transform.position, patrolDestination) < 1f || navMeshAgent.remainingDistance < 1f)
        {
            patrolDestination = GetRandomPoint();
        }

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            currentState = EnemyState.Idle;
            timer = idleTimer;
        }

        if (PlayerInChaseRange())
        {
            currentState = EnemyState.Chase;
        }
    }

    void Chase()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("Walk", true);

        navMeshAgent.speed = chaseSpeed;
        navMeshAgent.SetDestination(player.position);

        if (!PlayerInChaseRange())
        {
            currentState = EnemyState.Patrol;
        }
    }

    void Stunned()
    {
        // Aquí puedes implementar cualquier comportamiento específico cuando el enemigo esté aturdido
        // Por ejemplo, puedes desactivar la animación de caminar y hacer que el enemigo no se mueva
        animator.SetBool("Walk", false);
        animator.SetBool("Idle", true);
        currentState = EnemyState.Idle;
        stunTimer -= Time.deltaTime;
        if (stunTimer <= 0f)
        {
            isStunned = false;
            currentState = EnemyState.Idle; // Puedes cambiar esto al estado que prefieras después del aturdimiento
        }
    }

    bool PlayerInChaseRange()
    {
        return Vector3.Distance(transform.position, player.position) <= chaseRange;
    }

    Vector3 GetRandomPoint()
    {
        Vector3 randomDirection = Random.insideUnitSphere * patrolTimer;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, patrolTimer, 1);
        return hit.position;
    }
    public void StunEnemy()
    {
        // Este método puede ser llamado desde el script de la luz del jugador para aturdir al enemigo
        isStunned = true;
        stunTimer = stunDuration;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<StatePlayer>().Death();
            Debug.Log("SE llamo a la funcion death del jugador");
        }
    }
}



