using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;
using UnityEngine.UI;

public class PowerUpTextProManager : MonoBehaviour
{

    DelegateManager dm;

    PowerUpManager pm;

    //[SerializeField]
    //TextMeshProUGUI[] PowerUpObjects = new TextMeshProUGUI[3];

    [SerializeField]
    Image[] imageObject = new Image[3];

    [SerializeField]
    Sprite[] numberSprite = new Sprite[3];

    private void Start()
    {
        dm = DelegateManager.dm;
        pm = GameObject.FindObjectOfType<PowerUpManager>();
        int numberOfTextProObject = GameObject.Find("PowerUpHolder").transform.childCount;

        for (int i = 0; i < numberOfTextProObject; i++)
        {
            //PowerUpObjects[i] = GameObject.Find("PowerUpHolder").transform.GetChild(i).transform.GetChild(1).GetComponent<TextMeshProUGUI>();

            imageObject[i] = GameObject.Find("PowerUpHolder").transform.GetChild(i).transform.GetChild(1).GetComponent<Image>();
        }

        dm.powerUp_Water_Delegate += updateTheWaterText;
        dm.powerUp_Snow_Delegate += updateTheSnowText;
        dm.powerUp_Thunder_Delegate += updateTheThunderText;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.V))
        //{
        //    dm.powerUp_Water_Delegate();
        //}

        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    dm.powerUp_Snow_Delegate();
        //}

        //if (Input.GetKeyDown(KeyCode.N))
        //{
        //    dm.powerUp_Thunder_Delegate();
        //}
    }

    void updateTheWaterText()
    {
        
        if (pm.GetPowerUpLevel_Water() == 1)
        {
            //  PowerUpObjects[0].text = "1";
            imageObject[0].sprite = numberSprite[0];
        }
        else if(pm.GetPowerUpLevel_Water() == 2)
        {
            //  PowerUpObjects[0].text = "2";
            imageObject[0].sprite = numberSprite[1];
        }

        else if(pm.GetPowerUpLevel_Water() == 3)
        {
            //  PowerUpObjects[0].text = "3";
            imageObject[0].sprite = numberSprite[2];
        } 
    }

    void updateTheSnowText()
    {

        if (pm.GetPowerUpLevel_Snow() == 1)
        {
            //  PowerUpObjects[1].text = "1";
            imageObject[1].sprite = numberSprite[0];
        }
        else if (pm.GetPowerUpLevel_Snow() == 2)
        {
            // PowerUpObjects[1].text = "2";
            imageObject[1].sprite = numberSprite[1];
        }

        else if (pm.GetPowerUpLevel_Snow() == 3)
        {
            // PowerUpObjects[1].text = "3";
            imageObject[0].sprite = numberSprite[2];
        }
    }

    void updateTheThunderText()
    {

        if (pm.GetPowerUpLevel_Thunder() == 1)
        {
            // PowerUpObjects[2].text = "2";
            imageObject[2].sprite = numberSprite[0];
        }
        else if (pm.GetPowerUpLevel_Thunder() == 2)
        {
            //PowerUpObjects[2].text = "2";
            imageObject[2].sprite = numberSprite[1];
        }

        else if (pm.GetPowerUpLevel_Thunder() == 3)
        {
            //PowerUpObjects[2].text = "3";
            imageObject[2].sprite = numberSprite[2];
        }
    }

}
