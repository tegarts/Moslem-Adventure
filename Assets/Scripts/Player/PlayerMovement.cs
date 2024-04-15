using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Rigidbody2D rb;
    private Animator anim;

    private float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpPower = 16f;
    public bool isFacingRight = true;

    private bool moveEnabled = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if(horizontal != 0)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
       

        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if(isFacingRight && horizontal < 0f)
        {
            Flip();
        }

        anim.SetBool("jump", !IsGrounded());
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);

        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (moveEnabled)
        {
            horizontal = context.ReadValue<Vector2>().x;
        }
    }

    public void SetMovement(bool isEnabled)
    {
        moveEnabled = isEnabled;
    }
}
