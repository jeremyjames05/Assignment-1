using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public string playerTag = "Player"; // The tag of the player object
    public float detectionRadius = 10f;
    public float attackRadius = 2f;
    public float moveSpeed = 3f;
    public float rotationSpeed = 5f;

    private enum State
    {
        Idle,
        Chase,
        Attack
    }

    private State currentState = State.Idle;
    private Transform player;

    void Start()
    {
        // Find the player object based on the specified tag
        player = GameObject.FindGameObjectWithTag(playerTag).transform;

        if (player == null)
        {
            Debug.LogError("Player not found! Make sure the player has the specified tag.");
        }
    }

    void Update()
    {
        if (player == null)
            return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        switch (currentState)
        {
            case State.Idle:
                if (distanceToPlayer < detectionRadius)
                {
                    currentState = State.Chase;
                }
                break;

            case State.Chase:
                if (distanceToPlayer < attackRadius)
                {
                    currentState = State.Attack;
                }
                else if (distanceToPlayer > detectionRadius)
                {
                    currentState = State.Idle;
                }
                else
                {
                    ChasePlayer();
                }
                break;

            case State.Attack:
                if (distanceToPlayer > attackRadius)
                {
                    currentState = State.Chase;
                }
                else
                {
                    AttackPlayer();
                }
                break;
        }
    }

    void ChasePlayer()
    {
        if (player == null)
            return;

        // Rotate towards the player
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

        // Move towards the player
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void AttackPlayer()
    {
        // Implement your attack logic here
        // You can trigger animations, deal damage, etc.
        Debug.Log("Attacking player!");
    }
}
