using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

    [SerializeField]
    private float m_scrollSpeed = 2f;

    [SerializeField]
    private float m_scrollingLength = 2.5f; 

    private Vector2 m_startPos;

	void Start () {
        m_startPos = transform.position;
	}
	
	void Update ()
    {
        float newPos = Mathf.Repeat(Time.time * m_scrollSpeed, m_scrollingLength);
        transform.position = m_startPos + Vector2.right * newPos;
	}
}
