using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigidbody2;
    Animator animator;
    [SerializeField] float moveSpeed;
    float x;

    private void Awake()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        if (x > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (x < 0) transform.localScale = new Vector3(-1, 1, 1);

        animator.SetFloat("speed",Mathf.Abs(x));
    }

    private void FixedUpdate()
    {
        rigidbody2.linearVelocity = new Vector2(x * moveSpeed, rigidbody2.linearVelocity.y);
    }
}
