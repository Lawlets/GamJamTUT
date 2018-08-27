using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {

    [SerializeField]
    private float m_damage;

    [SerializeField]
    private float m_lightingDuration = 1.5f;

    private float m_lightningTimer = 0f;

    private string m_owner = "";

    private BoxCollider2D m_collider;
    private SpriteRenderer m_spriteRenderer;

    private bool m_isCoroutineIsOver = false;

	void Start () {

        m_collider = GetComponent<BoxCollider2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine("LightningCoroutine");
	}
	
	void Update () {
        if (m_isCoroutineIsOver)
        {
            StopAllCoroutines();
            Destroy(gameObject);
        }
	}

    public void SetOwner(string tag)
    {
        m_owner = tag;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == m_owner)
            return;

        Debug.Log("OnCollisionEnter with " + collision.gameObject);

        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Bullet")
        {
            Damageable dmg = collision.gameObject.GetComponent<Damageable>();
            dmg.TakeDamage(m_damage, true);
        }

    }

    private IEnumerator LightningCoroutine()
    {
        while(m_lightningTimer < m_lightingDuration)
        {
            m_lightningTimer += Time.deltaTime;
            yield return null;
        }

        m_isCoroutineIsOver = true;
        yield return null;
    }

}
