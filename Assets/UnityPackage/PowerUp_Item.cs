using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Item : MonoBehaviour
{
    public enum POWERUPTYPE
    {
        WATERDROP,

        SNOW,

        THUNDER
    }

    SpriteRenderer powerUpGFX;

    public POWERUPTYPE powerUp_Type;

    public Sprite[] powerGFX = new Sprite[3];

    private void Start()
    {
        int powerUpIndex = Random.Range(1, 4);
        powerUpGFX = transform.GetChild(0).GetComponent<SpriteRenderer>();
        switch (powerUpIndex)
        {
            case 1:
                powerUp_Type = POWERUPTYPE.WATERDROP;
                powerUpGFX.sprite = powerGFX[0];
                break;

            case 2:
                powerUp_Type = POWERUPTYPE.SNOW;
                powerUpGFX.sprite = powerGFX[1];
                break;

            case 3:
                powerUp_Type = POWERUPTYPE.THUNDER;
                powerUpGFX.sprite = powerGFX[2];
                break;
          
        }
    }
}
