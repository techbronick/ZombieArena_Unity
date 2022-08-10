using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public HealthBarScript healthBar;
    public StaminaBarScript staminaBar;
    public float currentHealth;
    public float maxHealth;

    public float currentStamina;
    public float maxStamina;


    void Start()
    {
        maxHealth = 100;
        maxStamina = 100;
        currentHealth = maxHealth / 2;
        healthBar.SetMaxHealth(maxHealth);

        currentStamina = maxStamina;
        staminaBar.SetMaxStamina(maxStamina);

    }

    private void Update()
    {
        healthBar.SetHealth(currentHealth);
        staminaBar.SetStamina(currentStamina);
    }

    public void PlayerDamaged(float amount)
    {
        currentHealth -= amount;
    }

    public void HealthIn()
    {
        if (currentHealth < 50.0f)
            currentHealth += 50.0f;
        else
            currentHealth = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ZombieHand")
        {
            PlayerDamaged(7);
        }
    }
}
