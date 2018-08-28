using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private PlayerTakeDamage playerDamage;
    float currentlerpTime;
    float maxLearpTime = 2;

    Vector3 currentScale;

    private SpriteRenderer m_spriteRenderer;
    private BoxCollider2D m_collider;
    private Damageable m_damageable;
    private Fighting m_fighting;
    private Rigidbody2D m_rigidBody;
    private Animator m_animator;
    public bool m_hasLightning = false;

    [SerializeField]
    private float m_verticalSpeed = 2f;
    [SerializeField]
    private float m_horizontalSpeed = 2f;

    private bool m_isIdle = false;
    private bool m_isShooting = false;
    private bool m_isLightningShooting = false;
    private bool m_isDead = false;


    void Start () {
        m_damageable = GetComponent<Damageable>();
        m_collider = GetComponent<BoxCollider2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_fighting = GetComponent<Fighting>();
        m_rigidBody = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();

        playerDamage = GetComponent<PlayerTakeDamage>();
        currentScale = transform.localScale;
    }
	
	void Update () {
        if (!playerDamage.IsDead())
        {
            UpdateMovement();
            UpdateButtonInput();
        }
        else
        {
            currentlerpTime += Time.deltaTime;
            transform.localScale = Vector3.Lerp(currentScale, Vector3.zero, currentlerpTime / maxLearpTime);
            if (currentlerpTime/maxLearpTime >= 1)
            {
                currentlerpTime = maxLearpTime;
            }
        }
        
	}

    private void FixedUpdate()
    {
        m_animator.SetBool("is_Idle", m_isIdle);
        m_animator.SetBool("is_Shooting", m_isShooting);
        m_animator.SetBool("is_LightningShooting",  m_isLightningShooting);
        m_animator.SetBool("is_Death", m_isDead);

    }

    private void UpdateMovement()
    {
        float x_axis = Input.GetAxis("Horizontal");
        float y_axis = Input.GetAxis("Vertical");

        Vector3 bas_move = transform.position;
        bas_move.x += (x_axis * m_horizontalSpeed) * Time.deltaTime;
        bas_move.y += (y_axis * m_verticalSpeed) * Time.deltaTime;
        m_rigidBody.MovePosition(bas_move);
    }

    private void EnableShootingAnimation()
    {
        m_isShooting = true;
        m_isLightningShooting = false;
        m_isIdle = false;
    }
    private void EnableLightningShootingAnimation()
    {
        m_isShooting = false;
        m_isLightningShooting = true;
        m_isIdle = false;
    }

    private void EnableIdleAnimation()
    {
        m_isShooting = false;
        m_isLightningShooting = false;
        m_isIdle = true;
    }

    private void UpdateButtonInput()
    {
        if (Input.GetButton("ButtonA"))
        {
            m_fighting.WaterShot();
            EnableShootingAnimation();
        }
        else if (Input.GetButtonDown("ButtonY"))
        {
            bool canAnimate = m_fighting.LightningShot();
            if(canAnimate)
                EnableLightningShootingAnimation();
        }
        else if (Input.GetButton("ButtonX"))
        {
            m_fighting.EnableFreezing();
            EnableShootingAnimation();
        }
        else if (Input.GetButtonUp("ButtonX"))
        {
            m_fighting.DisableFreezing();
            EnableIdleAnimation();
        }
        else
        {
            if (m_hasLightning)
                return;
            else
                EnableIdleAnimation();

        }
    }
}
