using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour {


    [SerializeField]
    private float m_life;

	void Start () {
		
	}
	
	void Update () {
		
	}

    public bool TakeDamage(float amount)
    {
        if (IsDead())
            return false;

        m_life -= amount;

        if (IsDead())
            Die();

        return true;
    }

    private bool IsDead()
    {
        return m_life > 0;
    }

    private void Die()
    {
        Debug.Log("Do something because Im Dead");
    }

}
