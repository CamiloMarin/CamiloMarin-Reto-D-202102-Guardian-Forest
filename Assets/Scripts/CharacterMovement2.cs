using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement2 : MonoBehaviour
{
    private Rigidbody2D rb2;
    private Animator anim2;
    private float moveSpeed2;
    private float jumpForce2 = 650;
    private float dirX2;
    private bool facingRight2 = true;
    private Vector3 localScale2;
    public static CharacterMovement2 Instance2;

    public float JumpForce2 { get => jumpForce2; set => jumpForce2 = value; }
    public float MoveSpeed2 { get => moveSpeed2; set => moveSpeed2 = value; }

    private void Start()
    {
        Instance2 = this;
        rb2 = GetComponent<Rigidbody2D>();
        anim2 = GetComponent<Animator>();
        localScale2 = transform.localScale;
        moveSpeed2 = 7f;
    }

    private void Update()
    {
        dirX2 = Input.GetAxisRaw("Horizontal") * moveSpeed2;

        if (Input.GetButtonDown("Jump") && rb2.velocity.y == 0) rb2.AddForce(Vector2.up * jumpForce2);

        if (Mathf.Abs(dirX2) > 0 && rb2.velocity.y == 0) anim2.SetBool("isRunning", true);
        else
            anim2.SetBool("isRunning", false);

        if (rb2.velocity.y == 0)
        {
            anim2.SetBool("isJumping", false);
            anim2.SetBool("isFalling", false);
        }

        if (rb2.velocity.y > 0)
            anim2.SetBool("isJumping", true);

        if (rb2.velocity.y < 0)
        {
            anim2.SetBool("isJumping", false);
            anim2.SetBool("isFalling", true);
        }
    }

    private void FixedUpdate()
    {
        rb2.velocity = new Vector2(dirX2, rb2.velocity.y);
    }

    private void LateUpdate()
    {
        if (dirX2 > 0)
            facingRight2 = true;
        else if (dirX2 < 0) facingRight2 = false;

        if (((facingRight2) && (localScale2.x < 0)) || ((!facingRight2) && (localScale2.x > 0))) localScale2.x *= -1;

        transform.localScale = localScale2;

    }
}
