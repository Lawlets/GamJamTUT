using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUpTextProManager : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI[] PowerUpObjects = new TextMeshProUGUI[3];

    private void Start()
    {
        int numberOfTextProObject = GameObject.Find("PowerUpHolder").transform.childCount;

        for (int i = 0; i < numberOfTextProObject; i++)
        {
            PowerUpObjects[i] = GameObject.Find("PowerUpHolder").transform.GetChild(i).transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        }
    }

}
