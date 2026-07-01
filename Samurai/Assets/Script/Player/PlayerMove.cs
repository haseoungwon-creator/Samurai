using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigidbody;

    Animator animator;

    [SerializeField] float moveSpeed = 4f;


    float x;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (GameManager.Instance.Currentstate == GameState.Story)
        {
            rigidbody.linearVelocity = Vector2.zero;
            animator.SetFloat("speed", 0);
            return;
        }
        x = Input.GetAxisRaw("Horizontal");
        if (x > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (x < 0) transform.localScale = new Vector3(-1, 1, 1);

        animator.SetFloat("speed",Mathf.Abs(x));
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.Currentstate == GameState.Story) { return;
            rigidbody.linearVelocity = Vector2.zero; }
            rigidbody.linearVelocity = new Vector2(x * moveSpeed, rigidbody.linearVelocity.y);
    }
}
