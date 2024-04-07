using UnityEngine;

public class ДвижениеПерсонажа : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool FacingRight = true;

    [Header("Настройки перемещения игрока")]
    [Range(0, 10f)] public float speed = 1f;
    [Range(0, 15f)] public float jumpForce = 8f;

    [Header("Настройки анимации игрока")]
    public Animator animator;

    [Space]
    [Header("Настройки заземления игрока")]
    public bool isGrounded = false;
    public float checkGroundOffsetY = -0.7f;
    public float checkGroundRadius = 0.3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = 0f;
        if (gameObject.CompareTag("Player1"))
        {
            moveInput = Input.GetAxisRaw("Horizontal");
            if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
        else if (gameObject.CompareTag("Player2"))
        {
            moveInput = Input.GetAxisRaw("Horizontal2");
            if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        animator.SetFloat("HorizontalMove", Mathf.Abs(moveInput));

        if (moveInput > 0 && !FacingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && FacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y + checkGroundOffsetY), checkGroundRadius);

        if (colliders.Length > 1)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
