using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : CharacterController
{
    private Camera mainCam;

    private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Animator anim;

    private void Awake()
    {
        mainCam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        OnMoveEvent += MoveEvent;
        OnLookEvent += LookEvent;
    }

    private void Update()
    {
        mainCam.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        anim.SetBool("IsMoving", (moveInput.magnitude != 0));
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        Vector2 worldPos = mainCam.ScreenToWorldPoint(value.Get<Vector2>());
        Vector2 newAim = (worldPos - (Vector2)transform.position).normalized;

        if (newAim.magnitude >= 0.5f)
            CallLookEvent(newAim);
    }

    private void MoveEvent(Vector2 direction)
    {
        rb.velocity = direction * 5;
    }

    private void LookEvent(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        sr.flipX = Mathf.Abs(rotZ) > 90f;
    }
}
