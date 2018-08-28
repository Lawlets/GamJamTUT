using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHelicopterMove : EnemyEntity
{

    [SerializeField]
    private GameObject m_bulletSpawnerPos;
    [SerializeField]
    private float m_shootingSpeed;

    [SerializeField]
    private int HP = 7;
    //移動方法(movement pattern)
    [SerializeField]
    private int movePattern;
    //移動速度(moving Speed)
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
    //パターン5で使用
    private Vector2 targetPos;

    private float iceSlow = 1.0f;
    // Use this for initialization
    void Start()
    {
        pos = transform.position;
        startPos = pos;
        player = GameObject.Find("player_WithHealth").GetComponent<Player>();
        targetPos = player.transform.position;
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        centerPos = camera.ViewportToWorldPoint(new Vector2(0.5f, 0.8f));
        underPos = camera.ViewportToWorldPoint(new Vector2(0.0f, 0.0f));
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
                //プレイヤーのy座標に合わせる
                pos.y += ((player.transform.position.y - pos.y) / 20) / iceSlow;
                transform.position = pos;
                break;
            case 3:
                //プレイヤーに突進
                pos.x += ((targetPos.x - startPos.x) / moveTime) / iceSlow;
                pos.y += ((targetPos.y - startPos.y) / moveTime) / iceSlow;
                bulletPattern = 5;
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
                var bulletInstance = GameObject.Instantiate(bullet, bulletSpawnerPos, transform.rotation) as GameObject;
                bulletInstance.GetComponent<Bullet>().SetOwner(gameObject.tag);
                rb = bulletInstance.GetComponent<Rigidbody2D>();
                rb.AddForce(shotDirection.normalized * m_shootingSpeed, ForceMode2D.Impulse);
                //Destroy(bulletInstance, 5f);
                break;
            case 2:
                //3wayショット
                for (int i = -1; i < 2; i++)
                {
                    bulletInstance = GameObject.Instantiate(bullet, bulletSpawnerPos, transform.rotation) as GameObject;
                    bulletInstance.transform.Rotate(0.0f, 0.0f, 30 * i);
                    bulletInstance.GetComponent<Bullet>().SetOwner(gameObject.tag);
                    rb = bulletInstance.GetComponent<Rigidbody2D>();
                    rb.AddForce(shotDirection.normalized * m_shootingSpeed, ForceMode2D.Impulse);
                    //Destroy(bulletInstance, 5f);
                }
                break;
            case 3:
                //5wayショット
                for (int i = -2; i < 3; i++)
                {
                    bulletInstance = GameObject.Instantiate(bullet, bulletSpawnerPos, transform.rotation) as GameObject;
                    bulletInstance.transform.Rotate(0.0f, 0.0f, 20 * i);
                    bulletInstance.GetComponent<Bullet>().SetOwner(gameObject.tag);
                    rb = bulletInstance.GetComponent<Rigidbody2D>();
                    rb.AddForce(shotDirection.normalized * m_shootingSpeed, ForceMode2D.Impulse);
                    //Destroy(bulletInstance, 5f);
                }
                break;
            case 4:
                //自機狙い
                bulletInstance = GameObject.Instantiate(bullet, bulletSpawnerPos, transform.rotation) as GameObject;
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
