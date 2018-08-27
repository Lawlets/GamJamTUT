using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public delegate void GameManagerSetupDone();
    public GameManagerSetupDone GAMEMANGER_SETUPDONE_DELEGATE;

    private void Awake()
    {
        if (gm != null && gm != this)
        {
            Destroy(gm);
        }
        else
        {
            gm = this;
            DontDestroyOnLoad(gm);
            if (GAMEMANGER_SETUPDONE_DELEGATE != null)
            {
                GAMEMANGER_SETUPDONE_DELEGATE();
            }
           
        }
    }

}
