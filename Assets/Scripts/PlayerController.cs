using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed;

    public Vector3 playerMoveDirection;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var inputX = Input.GetAxisRaw("Horizontal");
        var inputY = Input.GetAxisRaw("Vertical");

        playerMoveDirection = new Vector3(inputX, inputY).normalized;

        animator.SetFloat("moveX", inputX);
        animator.SetFloat("moveY", inputY);

        if (playerMoveDirection != Vector3.zero)
        {
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(playerMoveDirection.x * speed, playerMoveDirection.y * speed);
    }
}
