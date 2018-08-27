using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezingBullet : MonoBehaviour {

    [SerializeField]
    private float m_damage = 0f;
    [SerializeField]
    private float m_freezePower = 10f;

    private BoxCollider2D m_collider;

    private string m_owner = "";

	void Start ()
    {
        m_collider = GetComponent<BoxCollider2D>();
	}
	
	void Update ()
    {
		
	}

    public void SetOwner(string tag)
    {
        m_owner = tag;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("OnTriggerStay2D Freeze");

        if (collision.gameObject.tag == m_owner)
            return;

        if(collision.gameObject.tag == "Enemy")
        {
            Freezable freezable = collision.gameObject.GetComponent<Freezable>();
            freezable.Freeze(m_freezePower);
        }
    }

}
