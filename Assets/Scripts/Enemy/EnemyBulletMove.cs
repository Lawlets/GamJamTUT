using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = (transform.right.normalized) * -5.0f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
