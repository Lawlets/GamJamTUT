using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {


    [SerializeField]
    private List<GameObject> m_wavesList = null;
    private GameObject m_currentWaves = null;
    private int m_currentWavesIdx = -1;
    private bool m_isWavesOver = true;

    [SerializeField]
    private float m_timerForWaveCheck = 5f;
    private float m_timer = 0f;
    private bool m_timerFinish = true;

    private bool m_listEmpty = false;

	void Start () {
        if (m_wavesList == null)
            m_listEmpty = true;
        else if (m_wavesList.Count <= 0)
            m_listEmpty = true;
	}
	
	void Update () {
        if(!m_listEmpty)
        {
            if (m_timerFinish)
            {
                StopTimer();
                m_isWavesOver = CheckWavesOver();
                InstanciateWaves();
                StartTimer();
            }
        }
    }

    private bool CheckWavesOver()
    {
        if (m_currentWaves == null)
            return true;

        int enemyLeft = m_currentWaves.transform.childCount;
        if(enemyLeft == 0)
            return true;

        return false;
    }

    private void StartTimer()
    {
        if (m_listEmpty)
            return;
        m_timerFinish = false;
        StartCoroutine("TimerCoroutine");
    }

    private IEnumerator TimerCoroutine()
    {
        while(m_timer < m_timerForWaveCheck)
        {
            m_timer += Time.deltaTime;
            yield return null;
        }

        m_timerFinish = true;
        yield return null;
    }

    private void StopTimer()
    {
        m_timer = 0f;
        StopAllCoroutines();
    }


    private void InstanciateWaves()
    {
        if (m_wavesList.Count < 0 || !m_isWavesOver)
            return;
        if (m_currentWaves == null)
        {
            InstanciateFirstWaves();
        }
        else if (m_currentWavesIdx == m_wavesList.Count-1)
        {
            m_wavesList[m_wavesList.Count-1] = null;
            m_currentWaves = null;
            m_listEmpty = true;
            //TODO:
            // Show victory screen
        }
        else
        {
            m_currentWaves = null;
            m_currentWavesIdx++;
            m_currentWaves = Instantiate(m_wavesList[m_currentWavesIdx]);
            m_isWavesOver = false;
        }
    }

    private void InstanciateFirstWaves()
    {
        m_currentWavesIdx = 0;
        m_currentWaves = Instantiate(m_wavesList[m_currentWavesIdx]);
        m_isWavesOver = false;
    }
}
