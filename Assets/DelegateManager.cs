using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateManager : MonoBehaviour {

    public static DelegateManager dm;

    public delegate void PLAYERTAKEDAMAGE(int index);
    public delegate void PLAYERRECOVERHEALTH(int index);

    public  PLAYERTAKEDAMAGE playerTakeDamage_delegate;
    public  PLAYERRECOVERHEALTH playerRecoverHealth_delegate;

    private void Awake()
    {
        dm = this;
    }
}
