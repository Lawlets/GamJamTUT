using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBullet : Bullet {

	protected override void Start () {
        base.Start();
	}
	
	protected override void Update () {
        base.Update();
	}

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Damageable damageable = collision.gameObject.GetComponent<Damageable>();
            damageable.TakeDamage(m_damage);
            DestroyBullet();
        }

        base.OnCollisionEnter2D(collision);

    }
}
