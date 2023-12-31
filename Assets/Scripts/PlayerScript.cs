using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : CharacterController
{
    private Camera mainCam;

    [Header("Player")]
    [SerializeField] private SpriteRenderer playerRenderer;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Rigidbody2D playerRigidbody;

    public float playerSpeed;
    public float attackCooltime;
    private float attackRecent = 0f;

    private float rotZ = 0f;

    [Header("Weapon")]
    [SerializeField] private SpriteRenderer weaponRenderer;
    [SerializeField] private Transform weaponPivot;

    [Header("Bullet")]
    public GameObject bulletObject;
    [SerializeField] private Transform bulletSpawnPoint;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    private void Start()
    {
        OnMoveEvent += MoveEvent;
        OnLookEvent += LookEvent;
        OnAttackEvent += ShootEvent;
    }

    private void Update()
    {
        mainCam.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        attackRecent += Time.deltaTime;
    }

    #region MOVE
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        playerAnimator.SetBool("IsMoving", (moveInput.magnitude != 0));
        CallMoveEvent(moveInput);
    }

    private void MoveEvent(Vector2 direction)
    {
        playerRigidbody.velocity = direction * playerSpeed;
        // playerRigidbody.MovePosition(Vector3.Lerp(transform.position, (Vector3)direction, Time.deltaTime * playerSpeed));
        // playerRigidbody.MovePosition(transform.position + (Vector3)direction);
    }
    #endregion

    #region LOOK
    public void OnLook(InputValue value)
    {
        Vector2 worldPos = mainCam.ScreenToWorldPoint(value.Get<Vector2>());
        Vector2 newAim = (worldPos - (Vector2)transform.position).normalized;

        if (newAim.magnitude >= 0.5f)
            CallLookEvent(newAim);
    }

    private void LookEvent(Vector2 direction)
    {
        rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        weaponRenderer.flipY = Mathf.Abs(rotZ) > 90f;
        playerRenderer.flipX = Mathf.Abs(rotZ) > 90f;
        weaponPivot.rotation = Quaternion.Euler(0, 0, rotZ);
    }
    #endregion

    #region SHOOT
    public void OnShoot(InputValue value)
    {
        if (value.isPressed && attackRecent > attackCooltime)
        {
            CallAttackEvent();
            attackRecent = 0f;
        }
    }

    private void ShootEvent()
    {
        Instantiate(bulletObject, bulletSpawnPoint.position, Quaternion.Euler(0, 0, rotZ - 90));
    }
    #endregion

    #region SCROLL
    public void OnScroll(InputValue value)
    {
        if (value.Get<float>() > 0)
        {
            mainCam.orthographicSize -= (mainCam.orthographicSize > 2) ? 0.5f : 0f;
        }
        else if (value.Get<float>() < 0)
        {
            mainCam.orthographicSize += (mainCam.orthographicSize < 15) ? 0.5f : 0f;
        }
    }
    #endregion
}
