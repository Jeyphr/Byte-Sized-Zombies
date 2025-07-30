using TMPro;
using UnityEngine;

[System.Serializable]
public class CharacterHealth : MonoBehaviour
{
    [Header("Health Statistics")]
    public float maxHealth;
    public float health;
    public float regenAmount;
    public float regenDelay;

    [Header("Health Behaviours")]
    public bool isInvulnerable;
    public bool canRegenerate;
    public bool isDead;

    [Header("Object References")]
    public GameObject character;






    #region Getters and Setters
    public float MaxHealth
    {
        get { return maxHealth; }
        private set { maxHealth = value; }
    }
    public float Health
    {
        get { return health; }
        private set { health = value; }
    }
    public float RegenAmount
    {
        get { return regenAmount; }
        private set { regenAmount = value; }
    }
    public float RegenDelay
    {
        get { return regenDelay; }
        private set { regenDelay = value; }
    }
    #endregion






    #region Health Manipulation Scripts
    /// <summary>
    /// This is where the fun begins!
    /// </summary>
    public void TakeDamage(float damage)
    {
        if (isInvulnerable)
        {
            return;
        }

        //looks messy, will probably fix later
        //saving throw mechanic
        if ((damage >= maxHealth) && (health >= (maxHealth / 2)))
        {
            health = 1;
            return;
        }

        health -= damage;
        Mathf.Clamp(health, 0, maxHealth);

        if (health <= 0)
        {
            Die();
        }
    }

    public void HealDamage(float damage)
    {
        health += damage;
        Mathf.Clamp(health, 0, maxHealth);
    }
    #endregion






    #region Cleanup!
    public void Die()
    {
        isDead = true;
        Debug.Log(character.name + " has Died!");
    }   
    #endregion
}
