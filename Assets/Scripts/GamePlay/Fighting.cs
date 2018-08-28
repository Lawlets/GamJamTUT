using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting : MonoBehaviour
{

    PowerUpManager pm;
    [SerializeField]
    private GameObject m_bulletSpawner;

    [SerializeField]
    private GameObject[] m_bulletSpwner_LV2 = new GameObject[3];

    [SerializeField]
    private GameObject[] m_LightingbulletSpwner_LV2 = new GameObject[3];

    [SerializeField]
    private GameObject[] m_bulletSpwner_LV3 = new GameObject[5];

    [SerializeField]
    private float m_bulletForce = 0.55f;

    [SerializeField]
    private GameObject m_waterBullet;
    [SerializeField]
    private GameObject m_lightingBullet;
    [SerializeField]
    private GameObject m_iceBullet;

    #region WaterBulletValue


    [SerializeField]
    private float m_shotWaterCountdown = 1f;

    private float m_shotWaterTimer = 0f;
    private bool m_canShotWaterBullet = true;
    private bool m_clearWaterCoroutine = false;

    private IEnumerator m_waterCountdownCoroutine = null;

    #endregion

    #region LigtningBulletValue

    [SerializeField]
    private float m_shotLightningCountdown = 2f;

    private float m_shotLightningTimer = 0f;
    private bool m_canShotLightningBullet = true;
    private bool m_clearLightningCoroutine = false;

    private IEnumerator m_lightingCountdownCoroutine = null;

    #endregion


    void Start()
    {
        pm = GetComponent<PowerUpManager>();
        m_waterCountdownCoroutine = WaterCountdown();
        m_lightingCountdownCoroutine = LightningCountDown();
    }

    void Update()
    {
        if (m_clearWaterCoroutine)
            StopWaterCountdown();
        if (m_clearLightningCoroutine)
            StopLightningCountDown();
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

    private GameObject InstanciateBullet(GameObject bullet, Transform Spawne)
    {
        Vector3 entityPos = transform.position;
        Vector3 bulletSpawnerPos = Spawne.transform.position;

        Vector3 shotDirection = bulletSpawnerPos - entityPos;

        GameObject obj = Instantiate(bullet, Spawne.position, Quaternion.identity) as GameObject;
        obj.GetComponent<Bullet>().SetOwner(gameObject.tag);


        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        rb.AddForce(shotDirection.normalized * m_bulletForce, ForceMode2D.Impulse);

        return obj;
    }

    #region WaterBullet

    public void WaterShot()
    {
        if (!m_canShotWaterBullet)
            return;
        else
            StartWaterCountdow();

      

        switch (pm.playerPowerUpLevel[0])
        {
            case PowerUpManager.POWERUPLEVEL.levelOne:
                InstanciateBullet(m_waterBullet);
                break;
            case PowerUpManager.POWERUPLEVEL.levelTwo:
                InstanciateBullet(m_waterBullet, m_bulletSpwner_LV2[0].transform);
                InstanciateBullet(m_waterBullet, m_bulletSpwner_LV2[1].transform);
                InstanciateBullet(m_waterBullet, m_bulletSpwner_LV2[2].transform);
                break;
            case PowerUpManager.POWERUPLEVEL.LevelThree:
                InstanciateBullet(m_waterBullet, m_bulletSpwner_LV3[0].transform);
                InstanciateBullet(m_waterBullet, m_bulletSpwner_LV3[1].transform);
                InstanciateBullet(m_waterBullet, m_bulletSpwner_LV3[2].transform);
                InstanciateBullet(m_waterBullet, m_bulletSpwner_LV3[3].transform);
                InstanciateBullet(m_waterBullet, m_bulletSpwner_LV3[4].transform);
                break;
            default:
                break;
        }
    }


    private void StartWaterCountdow()
    {
        m_canShotWaterBullet = false;
        StartCoroutine(m_waterCountdownCoroutine);
    }

    private IEnumerator WaterCountdown()
    {
        while (m_shotWaterTimer < m_shotWaterCountdown)
        {
            m_shotWaterTimer += Time.deltaTime;
            yield return null;
        }

        m_clearWaterCoroutine = true;
        yield return null;
    }

    private void StopWaterCountdown()
    {
        m_canShotWaterBullet = true;
        m_shotWaterTimer = 0f;
        m_clearWaterCoroutine = false;
        StopCoroutine(m_waterCountdownCoroutine);
        m_waterCountdownCoroutine = WaterCountdown();
    }

    #endregion

    #region LightningBullet

    public bool LightningShot()
    {
        if (!m_canShotLightningBullet)
            return false;
        else
            StartLightningCountDown();

        switch (pm.playerPowerUpLevel[2])
        {
            case PowerUpManager.POWERUPLEVEL.levelOne:
                EnableLightning(m_lightingBullet);
                break;
            case PowerUpManager.POWERUPLEVEL.levelTwo:
                break;
            case PowerUpManager.POWERUPLEVEL.LevelThree:
                break;
            default:
                break;
        }

       
        return true;
    }

    private void EnableLightning(GameObject lightning )
    {
        Vector3 entityPos = transform.position;
        Vector3 bulletSpawnerPos = m_bulletSpawner.transform.position;

        Vector3 shotDirection = bulletSpawnerPos - entityPos;

        GameObject obj = Instantiate(lightning, bulletSpawnerPos, Quaternion.identity) as GameObject;
        Lightning ltn = obj.GetComponent<Lightning>();
        ltn.SetOwner(gameObject.tag, GetComponent<Player>());
    }

    private void EnableLightning(GameObject lightning, Transform Spawne)
    {
        Vector3 entityPos = transform.position;
        Vector3 bulletSpawnerPos = Spawne.transform.position;

        Vector3 shotDirection = bulletSpawnerPos - entityPos;

        GameObject obj = Instantiate(lightning, Spawne.position, Quaternion.identity) as GameObject;
        Lightning ltn = obj.GetComponent<Lightning>();
        ltn.SetOwner(gameObject.tag, GetComponent<Player>());
    }

    private void StartLightningCountDown()
    {
        m_canShotLightningBullet = false;
        StartCoroutine(m_lightingCountdownCoroutine);
    }

    private IEnumerator LightningCountDown()
    {
        while (m_shotLightningTimer < m_shotLightningCountdown)
        {
            m_shotLightningTimer += Time.deltaTime;
            yield return null;
        }

        m_clearLightningCoroutine = true;
        yield return null;
    }

    private void StopLightningCountDown()
    {
        m_clearLightningCoroutine = false;
        m_shotLightningTimer = 0f;
        m_canShotLightningBullet = true;
        StopCoroutine(m_lightingCountdownCoroutine);
        m_lightingCountdownCoroutine = LightningCountDown();
    }

    #endregion

    #region FreezeBullet

    public void EnableFreezing()
    {
        m_iceBullet.SetActive(true);
    }

    public void DisableFreezing()
    {
        m_iceBullet.SetActive(false);
    }

    #endregion

}

