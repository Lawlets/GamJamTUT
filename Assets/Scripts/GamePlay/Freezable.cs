using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezable : MonoBehaviour {

    [SerializeField]
    private float m_freezeResistance = 100f;

    private float m_currentFreezingValue = 0f;

	void Start () {
		
	}
	
	void Update () {
		
	}

    public bool IsFreezing()
    {
        return m_currentFreezingValue >= 100f;
    }

    public void Freeze(float freezingAmount)
    {
        if (IsFreezing())
            return;

        m_currentFreezingValue += freezingAmount;

        if (IsFreezing())
            Fall();
    }

    private void Fall()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

}
