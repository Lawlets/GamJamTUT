using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


    [SerializeField]
    private float m_bulletLifeTime = 1f;

    [SerializeField]
    protected float m_damage = 10f;

    private float m_timer = 0f;
    protected string m_ownerTag = "";


	protected virtual void Start () {
		
	}
	
	protected virtual void Update () {
        if (m_timer >= m_bulletLifeTime)
            DestroyBullet();

		if(m_timer < m_bulletLifeTime)
            m_timer += Time.deltaTime;
	}

    public void SetOwner(string tag)
    {
        m_ownerTag = tag;
    }

    protected virtual void DestroyBullet()
    {
        Destroy(gameObject);
    }


    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (m_ownerTag == collision.gameObject.tag)
            return;

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Damageable>().TakeDamage(m_damage);
            GetComponent<Animator>().SetBool("collide", true);

            // TODO:
            // play splash animation
            // wait the end of animation before destroying the bullet
            
        }
        else if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerTakeDamage>().TakeDamage();

            // TODO:
            // Deal damage to player
            // play splash animation
            // wait the end of animation before destroying the bullet

            DestroyBullet();
        }
        else
        {
            // TODO:
            // play splash animation
            // wait the end of animation before destroying the bullet
            DestroyBullet();
        }
        
    }


}
