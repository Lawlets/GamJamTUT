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

    public bool TakeDamage(float amount, bool isLightning = false)
    {
        if (IsDead())
            return false;

        m_life -= amount;

        if (isLightning)
            if (GetComponent<Animator>() != null)
                GetComponent<Animator>().SetBool("is_Alive", false);

        if (IsDead())
            if(GetComponent<Animator>() != null)
                GetComponent<Animator>().SetBool("is_Alive", false);

        return true;
    }

    private bool IsDead()
    {
        return m_life < 0;
    }

    private void Die()
    {
        if (gameObject.tag == "Enemy")
            Destroy(gameObject);
        Debug.Log("Do something because Im Dead");
    }

}
