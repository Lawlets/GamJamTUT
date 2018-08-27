using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting : MonoBehaviour {


    [SerializeField]
    private GameObject m_bulletSpawner;

    [SerializeField]
    private float m_bulletForce = 0.55f;

    [SerializeField]
    private GameObject m_waterBullet;
    [SerializeField]
    private GameObject m_lightingBullet;
    [SerializeField]
    private GameObject m_iceBullet;

    [SerializeField]
    private float m_shotCountdown = 1f;

    private float m_shotTimer = 0f;
    private bool m_canShot = true;
    private bool m_clearCoroutine = false;

    private IEnumerator m_waterCountdownCoroutine = null;
    private IEnumerator m_lightingCountdownCoroutine = null;


    void Start () {
        m_waterCountdownCoroutine = WaterCountdown();
        
	}
	
	void Update () {
        if (m_clearCoroutine)
            StopWaterCountdown();
	}

    public void WaterShot()
    {
        if (!m_canShot)
            return;
        else
            StartWaterCountdow();

        InstanciateBullet(m_waterBullet);
    }

    public void LightningShot()
    {
        //if (!m_canShot)
        //    return;
        //else
        //    StartWaterCountdow();
        //
        //InstanciateBullet(m_lightingBullet);
    }

    private GameObject InstanciateBullet(GameObject bullet)
    {
        Vector3 entityPos = transform.position;
        Vector3 bulletSpawnerPos = m_bulletSpawner.transform.position;

        Vector3 shotDirection = bulletSpawnerPos - entityPos;

        GameObject obj = Instantiate(bullet, bulletSpawnerPos, Quaternion.identity) as GameObject;
        obj.GetComponent<Bullet>().SetOwner(gameObject.tag);


        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        rb.AddForce(shotDirection.normalized * m_bulletForce, ForceMode2D.Impulse);

        return obj;
    }

    private void StartWaterCountdow()
    {
        m_canShot = false;
        StartCoroutine(m_waterCountdownCoroutine);
    }

    private IEnumerator WaterCountdown()
    {
        while(m_shotTimer < m_shotCountdown)
        {
            m_shotTimer += Time.deltaTime;
            yield return null;
        }

        m_clearCoroutine = true;
        yield return null;
    }

    private void StopWaterCountdown()
    {
        m_canShot = true;
        m_shotTimer = 0f;
        m_clearCoroutine = false;
        StopCoroutine(m_waterCountdownCoroutine);
        m_waterCountdownCoroutine = WaterCountdown();
    }
}

