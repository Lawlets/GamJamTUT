using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMove : MonoBehaviour {

    private GameObject target;
    private Transform targetPos;
    private Vector2 pos;
    private Vector2 startPos;
    public int pattern = 0;
    [SerializeField]
    private Vector2 speed = new Vector2(0.5f, 0.5f);
    private float rad;
    // Use this for initialization
    void Start () {

        if(pattern == 0)
        {
            GetComponent<Rigidbody2D>().velocity = (transform.right.normalized) * -10.0f;
        }
        
        pos = transform.position;
        startPos = pos;
        target = GameObject.Find("player_WithHealth");
        targetPos = target.transform;
        rad = Mathf.Atan2(
            target.transform.position.y - transform.position.y,
            target.transform.position.x - transform.position.x);
    }
	
	// Update is called once per frame
	void Update () {
        if (pattern == 2)
        {
            pos = transform.position;

            pos.x += speed.x * Mathf.Cos(rad);
            pos.y += speed.y * Mathf.Sin(rad);

            transform.position = pos;
        }

    }
}
