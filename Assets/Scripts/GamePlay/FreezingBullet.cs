using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezingBullet : MonoBehaviour {

    [SerializeField]
    private float m_damage = 0f;
    [SerializeField]
    private float m_freezePower = 10f;

    private BoxCollider2D m_collider;
    private Animator m_animator = null;

    private string m_owner = "";

    private bool m_isStart = false;
    private bool m_isFinish = false;


    void Start ()
    {
        m_collider = GetComponent<BoxCollider2D>();
        m_animator = GetComponent<Animator>();
	}
	
	void Update ()
    {
		
	}

    private void OnEnable()
    {
        m_isStart = true;
        m_isFinish = false;
    }

    private void OnDisable()
    {
        m_isStart = false;
        m_isFinish = true;
    }

    private void FixedUpdate()
    {
        m_animator.SetBool("is_Start", m_isStart);
        m_animator.SetBool("is_Finish", m_isFinish);
    }

    public void SetOwner(string tag)
    {
        m_owner = tag;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == m_owner)
            return;

        if(collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.GetComponent<Freezable>())
            {
                Freezable freezable = collision.gameObject.GetComponent<Freezable>();
                freezable.Freeze(m_freezePower);
            }
        }
    }

}
