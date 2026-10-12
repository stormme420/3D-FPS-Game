using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log("Player health: " + currentHealth);

        if (currentHealth <= 0f)
        {
            Debug.Log("Player has died.");
            Time.timeScale = 0f;
        }
    }
}
