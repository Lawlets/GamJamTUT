using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private CharacterController m_controller;
    private SpriteRenderer m_spriteRenderer;
    private BoxCollider2D m_collider;

    [SerializeField]
    private float m_verticalSpeed = 2f;
    [SerializeField]
    private float m_horizontalSpeed = 2f;


    void Start () {
    }
	
	void Update () {
        UpdateMovement();
        UpdateButtonInput();
	}

    private void UpdateMovement()
    {
        float x_axis = Input.GetAxis("Horizontal");
        float y_axis = Input.GetAxis("Vertical");

        Vector3 bas_move = transform.position;
        bas_move.x += (x_axis * m_horizontalSpeed) * Time.deltaTime;
        bas_move.y += (y_axis * m_verticalSpeed) * Time.deltaTime;
        transform.position = bas_move;
    }

    private void UpdateButtonInput()
    {
        if (Input.GetButtonDown("ButtonA"))
            Shot();
        if (Input.GetButtonDown("ButtonB"))
            Shot();
        if (Input.GetButtonDown("ButtonY"))
            Shot();
        if (Input.GetButtonDown("ButtonX"))
            Shot();
    }

    private void Shot()
    {
        Debug.Log("instanciate projectile");
    }

}
