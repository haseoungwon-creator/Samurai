using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;

    Animator animator;

    PlayerHealth playerHealth;

    PlayerDash playerDash;

    PlayerCharge playerCharge;

    [SerializeField] float moveSpeed = 4f;


    float x;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();
        playerDash = GetComponent<PlayerDash>();
        playerCharge = GetComponent<PlayerCharge>();
        GameManager.Instance.SetState(GameState.Playing);

    }
    private void Update()
    {
        Debug.Log(GameManager.Instance.Currentstate);

        if (GameManager.Instance.Currentstate == GameState.Story || playerHealth.isDead || playerCharge.isCharged)
        {
            rb.linearVelocity = Vector2.zero;
            animator.SetFloat("speed", 0);
            return;
        }

        if (playerDash.isDashing) return;

        x = Input.GetAxisRaw("Horizontal");
        if (x > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (x < 0) transform.localScale = new Vector3(-1, 1, 1);

        animator.SetFloat("speed", Mathf.Abs(x));
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.Currentstate == GameState.Story || playerHealth.isDead || playerCharge.isCharged)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        if (playerDash.isDashing) return;

        rb.linearVelocity = new Vector2(x * moveSpeed, rb.linearVelocity.y);
    }
}
