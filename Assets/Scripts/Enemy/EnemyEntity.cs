using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : MonoBehaviour {

    protected bool m_canUpdateMovement = true;

    public bool SetMovementUpdateBoolean  { get { return m_canUpdateMovement; } set { m_canUpdateMovement = value; } }

	void Start () {
		
	}
	
	void Update () {
		
	}


}
