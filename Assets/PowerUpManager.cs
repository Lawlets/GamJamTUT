using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {

	public enum POWERUPLEVEL
    {
        levelOne = 1,

        levelTwo = 2,

        LevelThree = 3
    }

    public POWERUPLEVEL[] playerPowerUpLevel = new POWERUPLEVEL[3];

    private int[] currentPowerLevel = new int[3];

    private void Start()
    {
        for (int i = 0; i < playerPowerUpLevel.Length; i++)
        {
            playerPowerUpLevel[i] = POWERUPLEVEL.levelOne;
            currentPowerLevel[i] = 1;
        }
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
}
