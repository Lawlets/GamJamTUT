using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUFOMove : EnemyEntity {

    [SerializeField]
    private GameObject m_bulletSpawnerPos;
    [SerializeField]
    private float m_shootingSpeed;

    [SerializeField]
    private GameObject m_Trigger;
    [SerializeField]
    private int HP = 5;

    //止まる位置(パターン3のみで使用)
    private Vector2 stopPos;
    //移動方法(movement pattern)
    [SerializeField]
    private int movePattern;
    //移動速度(moving Speed)
    [SerializeField]
    private float moveSpeed = 0.05f;
    //弾の種類(Types of bullets)
    private int bulletPattern = 1;
    //弾(bullet)
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    //発射間隔(firing interval)
    private float shootDelay = 1.0f;

    private Vector2 pos;
    private int moveTime = 200;
    private bool shootFlag = true;

    //初期位置
    private Vector2 startPos;
    private int stopCount = 0;
    private float shootTime = 0;
    //パターン2で使用
    private float fluffy = 0.0f;
    //プレイヤー
    private Player player;
    //カメラ
    private Camera camera;
    //パターン2で使用
    private Vector2 centerPos;
    private Vector2 underPos;

    private float iceSlow = 1.0f;
    // Use this for initialization
    void Start()
    {
        pos = transform.position;
        startPos = pos;
        player = GameObject.Find("player_WithHealth").GetComponent<Player>();
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        centerPos = camera.ViewportToWorldPoint(new Vector2(0.5f, 0.8f));
        underPos = camera.ViewportToWorldPoint(new Vector2(0.0f, 0.0f));
        stopPos = m_Trigger.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_canUpdateMovement)
            EnemyMove(movePattern);
        //transform.position = pos;
        if (shootFlag == true)
        {
            shootTime += 1 * Time.deltaTime;
        }
        if (shootTime > shootDelay)
        {
            EnemyShot(bulletPattern);
            shootTime = 0;
        }
        //if (Input.GetKey("z"))
        //{
        //    iceSlow += 0.25f;
        //}

        //if (iceSlow >= 1)
        //{
        //    iceSlow -= 0.1f;
        //}
        //else iceSlow = 1.0f;
    }

    public void EnemyMove(int movePattern)
    {
        switch (movePattern)
        {
            case 1:
                //横に移動
                pos.x -= (moveSpeed / iceSlow) * Time.deltaTime;
                transform.position = pos;

                break;
            case 2:
                //直角に曲がる
                // pos.x -= moveSpeed;
                float moveX = 0.0f;
                float moveY = 0.0f;
                if (pos.x - centerPos.x > 0.2)
                {
                    moveX = (centerPos.x - startPos.x) / moveTime;
                    moveY = (centerPos.y - startPos.y) / moveTime;
                }
                else
                {
                    moveX = (underPos.x - centerPos.x) / (moveTime + 40);
                    moveY = (underPos.y - centerPos.y) / (moveTime + 40);
                }


                pos.x += (moveX / iceSlow) * Time.deltaTime;
                pos.y += (moveY / iceSlow) * Time.deltaTime;
                transform.position = pos;
                break;
            case 3:
                //一定位置で止まる
                int stopTime = 60;
                pos.x += ((stopPos.x - pos.x) / stopTime) / iceSlow;
                pos.y += ((stopPos.y - pos.y) / stopTime) / iceSlow;
                stopCount++;
                if (stopCount < stopTime)
                {
                    shootFlag = false;
                }
                else shootFlag = true;

                bulletPattern = 4;
                transform.position = pos;
                break;
            default:
                //
                break;
        }

    }

    public void EnemyShot(int bulletPattern)
    {

        Vector3 entityPos = transform.position;
        Vector3 bulletSpawnerPos = m_bulletSpawnerPos.transform.position;

        Vector3 shotDirection = bulletSpawnerPos - entityPos;

        Rigidbody2D rb = null;

        switch (bulletPattern)
        {
            case 1:
                //通常ショット
                var bulletInstance = GameObject.Instantiate(bullet, pos, transform.rotation) as GameObject;
                //Destroy(bulletInstance, 5f);
                bulletInstance.GetComponent<Bullet>().SetOwner(gameObject.tag);
                rb = bulletInstance.GetComponent<Rigidbody2D>();
                rb.AddForce(shotDirection.normalized * m_shootingSpeed, ForceMode2D.Impulse);
                break;
            case 2:
                //3wayショット
                for (int i = -1; i < 2; i++)
                {
                    bulletInstance = GameObject.Instantiate(bullet, pos, transform.rotation) as GameObject;
                    bulletInstance.transform.Rotate(0.0f, 0.0f, 30 * i);
                    //Destroy(bulletInstance, 5f);
                    bulletInstance.GetComponent<Bullet>().SetOwner(gameObject.tag);
                    rb = bulletInstance.GetComponent<Rigidbody2D>();
                    rb.AddForce(shotDirection.normalized * m_shootingSpeed, ForceMode2D.Impulse);
                }
                break;
            case 3:
                //5wayショット
                for (int i = -2; i < 3; i++)
                {
                    bulletInstance = GameObject.Instantiate(bullet, pos, transform.rotation) as GameObject;
                    bulletInstance.transform.Rotate(0.0f, 0.0f, 20 * i);
                    //Destroy(bulletInstance, 5f);
                    bulletInstance.GetComponent<Bullet>().SetOwner(gameObject.tag);
                    rb = bulletInstance.GetComponent<Rigidbody2D>();
                    rb.AddForce(shotDirection.normalized * m_shootingSpeed, ForceMode2D.Impulse);
                }
                break;
            case 4:
                //自機狙い
                bulletInstance = GameObject.Instantiate(bullet, pos, transform.rotation) as GameObject;
                //EnemyBulletMove bulletObject = bulletInstance.GetComponent<EnemyBulletMove>();
                //bulletObject.pattern = 2;
                bulletInstance.GetComponent<Bullet>().SetOwner(gameObject.tag);
                rb = bulletInstance.GetComponent<Rigidbody2D>();
                rb.AddForce(shotDirection.normalized * m_shootingSpeed, ForceMode2D.Impulse);
                //Destroy(bulletInstance, 5f);
                break;
            default:
                //
                break;
        }
    }
}
