using UnityEngine;

public class AiHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public AiAgent agent;

    private void Start()
    {
        currentHealth = maxHealth;

        var rigidBodies = GetComponentsInChildren<Rigidbody>();
        foreach (var rigidBody in rigidBodies)
        {
            HitBox hitBox = rigidBody.gameObject.AddComponent<HitBox>();
            hitBox.health = this;

        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0.0f)
        {
            Die();
        }
    }

    private void Die()
    {
        agent.stateMachine.ChangeState(AiStateId.Death);
    }
}
