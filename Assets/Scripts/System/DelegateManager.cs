using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateManager : MonoBehaviour {

    public static DelegateManager dm;

    public delegate void PLAYERTAKEDAMAGE(int index);
    public delegate void PLAYERRECOVERHEALTH(int index);

    public delegate void LEVELUPWATERPOWERUP();
    public delegate void LEVELUPSNOWPOWERUP();
    public delegate void LEVELUPTHUNERPOWERUP();

    public  PLAYERTAKEDAMAGE playerTakeDamage_delegate;
    public  PLAYERRECOVERHEALTH playerRecoverHealth_delegate;

    public LEVELUPWATERPOWERUP powerUp_Water_Delegate;
    public LEVELUPSNOWPOWERUP powerUp_Snow_Delegate;
    public LEVELUPTHUNERPOWERUP powerUp_Thunder_Delegate;

   

    private void Awake()
    {
        dm = this;
    }
}
