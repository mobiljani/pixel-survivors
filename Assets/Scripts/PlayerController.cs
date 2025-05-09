using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public Vector3 playerMoveDirection;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject destroyEffect;
    [SerializeField] private float speed;
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

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

    public void TakeDamage(float damage = 1f)
    {
        health -= damage;

        if (health <= 0)
        {
            gameObject.SetActive(false);
            Instantiate(destroyEffect, transform.position, transform.rotation);
        }
    }
}
