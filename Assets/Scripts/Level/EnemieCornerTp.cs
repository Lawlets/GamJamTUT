using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieCornerTp : MonoBehaviour {

    [SerializeField]
    private GameObject m_tpExit = null;

    private Vector3 m_exitPos = Vector3.one;



	void Start () {
        m_exitPos = m_tpExit.transform.position;
        
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("collisz with enemies");

            GameObject gao = collision.gameObject;

            gao.GetComponent<EnemyEntity>().ResetPosition();

            //Vector3 oldEnemyPos = gao.transform.position;
            //Vector3 newEnemyPos = new Vector3(m_exitPos.x, oldEnemyPos.y, oldEnemyPos.z);
            //gao.transform.position = newEnemyPos;

        }
    }

}
