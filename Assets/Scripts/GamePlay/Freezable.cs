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
        GetComponent<Animator>().SetBool("is_Alive", true);
        GetComponent<Animator>().SetBool("Start", true);

        if (IsFreezing())
        {
            GetComponent<Animator>().SetBool("is_Alive", false);
            GetComponent<Animator>().SetBool("Start", false);
        }
            
    }

    private void Fall()
    {
        if(gameObject.tag == "Enemy")
        {
            GetComponent<EnemyEntity>().SetMovementUpdateBoolean = false;
        }

        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

}
