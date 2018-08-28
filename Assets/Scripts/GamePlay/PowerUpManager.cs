using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {


    DelegateManager dm;

	public enum POWERUPLEVEL
    {
        levelOne = 1,

        levelTwo = 2,

        LevelThree = 3
    }

    public POWERUPLEVEL[] playerPowerUpLevel = new POWERUPLEVEL[3];

    [SerializeField]
    private int[] currentPowerLevel = new int[3];

    private void Start()
    {
        for (int i = 0; i < playerPowerUpLevel.Length; i++)
        {
            playerPowerUpLevel[i] = POWERUPLEVEL.levelOne;
            currentPowerLevel[i] = 1;
        }

        dm = DelegateManager.dm;

        dm.powerUp_Water_Delegate += powerUpWaterDelegate;
        dm.powerUp_Snow_Delegate += powerUpSnowDelegate;
        dm.powerUp_Thunder_Delegate += powerUpThunderDelegate;
    }

  
    public int GetPowerUpLevel_Water()
    {
        return currentPowerLevel[0];
    }

    public int GetPowerUpLevel_Snow()
    {
        return currentPowerLevel[1];
    }

    public int GetPowerUpLevel_Thunder()
    {
        return currentPowerLevel[2];
    }

    void powerUpWaterDelegate()
    {

        if (playerPowerUpLevel[0] == POWERUPLEVEL.levelOne)
        {
            playerPowerUpLevel[0] = POWERUPLEVEL.levelTwo;
            currentPowerLevel[0]++;
        }
        else if (playerPowerUpLevel[0] == POWERUPLEVEL.levelTwo)
        {
            playerPowerUpLevel[0] = POWERUPLEVEL.LevelThree;
            currentPowerLevel[0]++;
        }
        else
        {
            playerPowerUpLevel[0] = POWERUPLEVEL.LevelThree;
        }

    }

    void powerUpSnowDelegate()
    {
        if (playerPowerUpLevel[1] == POWERUPLEVEL.levelOne)
        {
            playerPowerUpLevel[1] = POWERUPLEVEL.levelTwo;
            currentPowerLevel[1]++;
        }
        else if (playerPowerUpLevel[1] == POWERUPLEVEL.levelTwo)
        {
            playerPowerUpLevel[1] = POWERUPLEVEL.LevelThree;
            currentPowerLevel[1]++;
        }
        else
        {
            playerPowerUpLevel[1] = POWERUPLEVEL.LevelThree;
        }
    }

    void powerUpThunderDelegate()
    {
        if (playerPowerUpLevel[2] == POWERUPLEVEL.levelOne)
        {
            playerPowerUpLevel[2] = POWERUPLEVEL.levelTwo;
            currentPowerLevel[2]++;
        }
        else if (playerPowerUpLevel[2] == POWERUPLEVEL.levelTwo)
        {
            playerPowerUpLevel[2] = POWERUPLEVEL.LevelThree;
            currentPowerLevel[2]++;
        }
        else
        {
            playerPowerUpLevel[2] = POWERUPLEVEL.LevelThree;
        }
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.GetComponent<PowerUp_Item>())
        {
            PowerUp_Item powerUp = collision.gameObject.GetComponent<PowerUp_Item>();

            switch (powerUp.powerUp_Type)
            {
                case PowerUp_Item.POWERUPTYPE.WATERDROP:
                    dm.powerUp_Water_Delegate();
                    Destroy(collision.gameObject);
                    break;
                case PowerUp_Item.POWERUPTYPE.SNOW:
                    dm.powerUp_Snow_Delegate();
                    Destroy(collision.gameObject);
                    break;
                case PowerUp_Item.POWERUPTYPE.THUNDER:
                    dm.powerUp_Thunder_Delegate();
                    Destroy(collision.gameObject);
                    break;
                default:
                    break;
            }

            
        }
    }
}
