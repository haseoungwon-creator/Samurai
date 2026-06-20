using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    Rigidbody2D rb;
    Animator anim;
    float inputX;

    bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // 좌우 이동
        inputX = Input.GetAxisRaw("Horizontal");

        // 애니메이션
        anim.SetFloat("speed", Mathf.Abs(inputX));
        if (inputX > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (inputX < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        // 점프 입력
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        // 이동 (y 유지)
        rb.linearVelocity = new Vector2(inputX * moveSpeed, rb.linearVelocity.y);
    }

    // 바닥 체크
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}