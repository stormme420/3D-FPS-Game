using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float health = 100f;
    public float moveSpeed = 2.5f;
    public float attackRange = 1.8f;
    public float attackDamage = 10f;
    public float attackCooldown = 1f;

    private Transform player;
    private float nextAttackTime;
    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player")?.transform;
    }

    private void Update()
    {
        if (player == null)
        {
            return;
        }

        Vector3 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        if (distanceToPlayer > 0.1f)
        {
            Vector3 moveDirection = directionToPlayer.normalized;
            moveDirection.y = 0f;

            if (distanceToPlayer > attackRange)
            {
                controller.Move(moveDirection * moveSpeed * Time.deltaTime);
            }

            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directionToPlayer.x, 0f, directionToPlayer.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 8f);
        }

        if (distanceToPlayer <= attackRange && Time.time >= nextAttackTime)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
            }

            nextAttackTime = Time.time + attackCooldown;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0f)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(10);
            }

            Destroy(gameObject);
        }
    }
}
