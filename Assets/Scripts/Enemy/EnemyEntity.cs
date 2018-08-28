using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : MonoBehaviour {

    protected bool m_canUpdateMovement = true;

    public bool SetMovementUpdateBoolean  { get { return m_canUpdateMovement; } set { m_canUpdateMovement = value; } }

    protected Vector2 pos;
    protected Vector2 startPos;


    void Start () {
		
	}
	
	void Update () {
		
	}

    public void ResetPosition()
    {
        pos = startPos;
    }

}
