using System.Collections;
using TMPro;
using Unity.VisualScripting;
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
    public bool canSavingThrow;
    public bool canRegenerate;
    public bool isDead;
    private bool regenerating;

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

    public void TakeHit()
    {
        if (isInvulnerable)
        {
            return;
        }

        TakeDamage(1f);

        if (!canRegenerate || regenerating)
        {
            return;
        }

        StartCoroutine(regenerateHealth());
    }
   
    public void TakeDamage(float damage)
    {
        //looks messy, will probably fix later
        //saving throw mechanic
        if ((damage >= maxHealth) && (health >= (maxHealth / 2)) && canSavingThrow)
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

    private IEnumerator regenerateHealth()
    {
        regenerating = true;
        yield return new WaitForSeconds(regenDelay);
        while (health < maxHealth)
        {
            HealDamage(regenAmount);
            yield return new WaitForSeconds(1);
        }
        regenerating = false;
        StopCoroutine(regenerateHealth());
    }




    #region Cleanup!
    public void Die()
    {
        isDead = true;
        Debug.Log(character.name + " has Died!");
    }   
    #endregion
}
