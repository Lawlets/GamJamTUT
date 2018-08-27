using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUpTextProManager : MonoBehaviour
{

    DelegateManager dm;

    PowerUpManager pm;

    [SerializeField]
    TextMeshProUGUI[] PowerUpObjects = new TextMeshProUGUI[3];

    private void Start()
    {
        dm = DelegateManager.dm;
        pm = GameObject.FindObjectOfType<PowerUpManager>();
        int numberOfTextProObject = GameObject.Find("PowerUpHolder").transform.childCount;

        for (int i = 0; i < numberOfTextProObject; i++)
        {
            PowerUpObjects[i] = GameObject.Find("PowerUpHolder").transform.GetChild(i).transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        }

        dm.powerUp_Water_Delegate += updateTheWaterText;
        dm.powerUp_Snow_Delegate += updateTheSnowText;
        dm.powerUp_Thunder_Delegate += updateTheThunderText;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            dm.powerUp_Water_Delegate();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            dm.powerUp_Snow_Delegate();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            dm.powerUp_Thunder_Delegate();
        }
    }

    void updateTheWaterText()
    {
        
        if (pm.GetPowerUpLevel_Water() == 1)
        {
            PowerUpObjects[0].text = "1";
        }
        else if(pm.GetPowerUpLevel_Water() == 2)
        {
            PowerUpObjects[0].text = "2";
        }

        else if(pm.GetPowerUpLevel_Water() == 3)
        {
            PowerUpObjects[0].text = "3";
        } 
    }

    void updateTheSnowText()
    {

        if (pm.GetPowerUpLevel_Snow() == 1)
        {
            PowerUpObjects[1].text = "1";
        }
        else if (pm.GetPowerUpLevel_Snow() == 2)
        {
            PowerUpObjects[1].text = "2";
        }

        else if (pm.GetPowerUpLevel_Snow() == 3)
        {
            PowerUpObjects[1].text = "3";
        }
    }

    void updateTheThunderText()
    {

        if (pm.GetPowerUpLevel_Thunder() == 1)
        {
            PowerUpObjects[2].text = "2";
        }
        else if (pm.GetPowerUpLevel_Thunder() == 2)
        {
            PowerUpObjects[2].text = "2";
        }

        else if (pm.GetPowerUpLevel_Thunder() == 3)
        {
            PowerUpObjects[2].text = "3";
        }
    }

}
