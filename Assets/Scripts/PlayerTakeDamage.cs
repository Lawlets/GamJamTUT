using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    [SerializeField]
    [Range(0, 3)]
    int PlayerHealth;

    [SerializeField]
    float timeToTurnInvincibilityOff = 2;

    SpriteRenderer playerSprite;

    [SerializeField]
    float timeBetweenFlasing = 0.5f;
    float currentFlastingTime = 0;
    float totalTimeOfInvincibility = 0;

    [SerializeField]
    bool StartInvincibility = false;

    private void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
      PlayerHealth = 3;
    }

    private void Update()
    {
        if (StartInvincibility)
        {
            currentFlastingTime += Time.deltaTime;
            if (currentFlastingTime >= timeBetweenFlasing)
            {
                totalTimeOfInvincibility += currentFlastingTime;
                currentFlastingTime = 0;
                playerSprite.enabled = !playerSprite.enabled;
            }
            if (totalTimeOfInvincibility >= timeToTurnInvincibilityOff)
            {
                StartInvincibility = false;
                totalTimeOfInvincibility = 0;
                currentFlastingTime = 0;
                playerSprite.enabled = true;
            }
        }
    }

    public void RecoverHealth()
    {
        PlayerHealth++;
        if (PlayerHealth > 3)
        {
            PlayerHealth = 3;
        }
        DelegateManager.dm.playerRecoverHealth_delegate(PlayerHealth);
    }

    public void TakeDamage()
    {
        if (StartInvincibility == false)
        {
            StartInvincibility = true;
            DelegateManager.dm.playerTakeDamage_delegate(PlayerHealth);
            PlayerHealth--;

            if (PlayerHealth < 0)
            {
                PlayerHealth = 0;
            }
        }
       
    }

    public int GetCurrentHealth()
    {
        return PlayerHealth;
    }

    public bool IsDead()
    {
        
        return (PlayerHealth <= 0);
    }
}
