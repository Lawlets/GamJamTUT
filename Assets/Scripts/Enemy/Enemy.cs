using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    //移動方法(movement pattern)
    public int movePattern;
    //移動速度(moving Speed)
    public float moveSpeed;
    //弾の種類(Types of bullets)
    public int bulletPattern;
    //弾(bullet)
    public GameObject bullet;
    //発射間隔(firing interval)
    public float shootDelay;


    private Vector2 pos;
    private Vector2 startPos;
    private float shootTime = 0.0f;
    //パターン2で使用
    private float fluffy = 0.0f;
    
    //パターン3で使用
    private Vector2 stopPos;
    // Use this for initialization
    void Start () {
        pos = transform.position;
        startPos = pos;
        stopPos = new Vector2(startPos.x - 4.0f, startPos.y);
	}
	
	// Update is called once per frame
	void Update () {
        EnemyMove(movePattern);
        transform.position = pos;
        shootTime += 1 * Time.deltaTime;
        if(shootTime > shootDelay)
        {
            EnemyShot(bulletPattern);
            shootTime = 0;
        }
       /* var c = Input.inputString;
        movePattern = int.Parse(c);
        if (Input.anyKey)
        {
            pos = startPos;
        }
        */
	}

    public void EnemyMove(int movePattern)
    {
        switch (movePattern)
        {
            case 1:
                //横に移動
                pos.x -= moveSpeed;
                break;
            case 2:
                //揺れながら移動
                pos.x -= moveSpeed;
                fluffy += 0.015f;
                pos.y = startPos.y + Mathf.Sin(Mathf.PI * 2 * fluffy) * 1.5f;
                break;
            case 3:
                //一定位置で止まる
                pos.x += (stopPos.x - pos.x) / 30;
                break;
            default:
                //
                break;
        }

    }

    public void EnemyShot(int bulletPattern)
    {
        
        switch (bulletPattern)
        {
            case 1:
                //通常ショット
               var bulletInstance = GameObject.Instantiate(bullet, pos, transform.rotation) as GameObject;
                break;
            case 2:
                //3wayショット
                for (int i = -1; i < 2; i++)
                {
                    bulletInstance = GameObject.Instantiate(bullet, pos, transform.rotation) as GameObject;
                    bulletInstance.transform.Rotate(0.0f, 0.0f, 30 * i);
                }
                break;
            case 3:
                //5wayショット
                for (int i = -2; i < 3; i++)
                {
                    bulletInstance = GameObject.Instantiate(bullet, pos, transform.rotation) as GameObject;
                    bulletInstance.transform.Rotate(0.0f, 0.0f, 20 * i);
                }
                break;
            default:
                //
                break;
        }
    }
}
