using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUIManager : MonoBehaviour
{

    DelegateManager dm;

    [SerializeField]
    GameObject[] HeartUI = new GameObject[3];

    PlayerTakeDamage player;

   

    private void Awake()
    {

    }

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerTakeDamage>();

        dm = DelegateManager.dm;

        dm.playerTakeDamage_delegate += TurnHeartBlack;
        dm.playerRecoverHealth_delegate += TurnHeartWhite;

        int heartUIHolderCount = GameObject.Find("UI_HeartHolder").transform.childCount;

        for (int i = 0; i < heartUIHolderCount; i++)
        {
            HeartUI[i] = GameObject.Find("UI_HeartHolder").transform.GetChild(i).transform.gameObject;
        }

        RecoverAllHealth();
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Z))
    //    {
    //        TurnHeartBlack(2);
    //    }

    //    if (Input.GetKeyDown(KeyCode.X))
    //    {
    //        TurnHeartWhite(2);
    //    }
    //}

    void TurnHeartBlack(int index)
    {
       
        switch (index)
        {
            case 3:
                HeartUI[2].transform.GetChild(0).gameObject.SetActive(false);
                HeartUI[2].transform.GetChild(1).gameObject.SetActive(true);
                break;

            case 2:
                HeartUI[1].transform.GetChild(0).gameObject.SetActive(false);
                HeartUI[1].transform.GetChild(1).gameObject.SetActive(true);

                break;

            case 1:
                HeartUI[0].transform.GetChild(0).gameObject.SetActive(false);
                HeartUI[0].transform.GetChild(1).gameObject.SetActive(true);
                break;
        }
    }

    void TurnHeartWhite(int index)
    {
        switch (index)
        {
            case 3:
                HeartUI[2].transform.GetChild(0).gameObject.SetActive(true);
                HeartUI[2].transform.GetChild(1).gameObject.SetActive(false);
                break;

            case 2:
                HeartUI[1].transform.GetChild(0).gameObject.SetActive(true);
                HeartUI[1].transform.GetChild(1).gameObject.SetActive(false);
                break;

            case 1:
                HeartUI[0].transform.GetChild(0).gameObject.SetActive(true);
                HeartUI[0].transform.GetChild(1).gameObject.SetActive(false);
                break;
        }
    }


    void RecoverAllHealth()
    {
        HeartUI[2].transform.GetChild(0).gameObject.SetActive(true);
        HeartUI[2].transform.GetChild(1).gameObject.SetActive(false);
        HeartUI[1].transform.GetChild(0).gameObject.SetActive(true);
        HeartUI[1].transform.GetChild(1).gameObject.SetActive(false);
        HeartUI[0].transform.GetChild(0).gameObject.SetActive(true);
        HeartUI[0].transform.GetChild(1).gameObject.SetActive(false);
    }

    void LoseAllHealth()
    {
        HeartUI[2].transform.GetChild(0).gameObject.SetActive(false);
        HeartUI[2].transform.GetChild(1).gameObject.SetActive(true);
        HeartUI[1].transform.GetChild(0).gameObject.SetActive(false);
        HeartUI[1].transform.GetChild(1).gameObject.SetActive(true);
        HeartUI[0].transform.GetChild(0).gameObject.SetActive(false);
        HeartUI[0].transform.GetChild(1).gameObject.SetActive(true);
    }
}
