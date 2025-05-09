using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private GameObject destroyEffect;
    [SerializeField] private float speed;

    private Vector3 direction;

    void FixedUpdate()
    {
        if (PlayerController.Instance.gameObject.activeSelf)
        {
            if (PlayerController.Instance.transform.position.x < transform.position.x)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }

            direction = (PlayerController.Instance.transform.position - transform.position).normalized;
            rb.linearVelocity = new Vector2(direction.x * speed, direction.y * speed);
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            PlayerController.Instance.TakeDamage(1);
            Instantiate(destroyEffect, transform.position, transform.rotation);
        }
    }
}
