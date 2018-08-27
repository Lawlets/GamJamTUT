using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    [SerializeField]
    [Range(0, 3)]
    int PlayerHealth;

    private void Start()
    { 
      PlayerHealth = 3;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            TakeDamage();

          
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            RecoverHealth();
          
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
        DelegateManager.dm.playerTakeDamage_delegate(PlayerHealth);
        PlayerHealth--;

        if (PlayerHealth < 0)
        {
            PlayerHealth = 0;
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
