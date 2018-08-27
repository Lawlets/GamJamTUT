using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting : MonoBehaviour {


    [SerializeField]
    private GameObject m_bulletSpawner;

    [SerializeField]
    private GameObject m_bullet;

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void Shot()
    {
        Vector3 entityPos = transform.position;
        Vector3 bulletSpawnerPos = m_bulletSpawner.transform.position;

        Vector3 shotDirection = bulletSpawnerPos - entityPos;

        GameObject obj = Instantiate(m_bullet, bulletSpawnerPos, Quaternion.identity) as GameObject;
        obj.GetComponent<Bullet>().SetOwner(gameObject.tag);


        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        rb.AddForce(shotDirection.normalized, ForceMode2D.Impulse);
    }
}
