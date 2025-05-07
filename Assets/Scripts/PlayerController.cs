using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var inputX = Input.GetAxisRaw("Horizontal");
        var inputY = Input.GetAxisRaw("Vertical");

        rb.linearVelocity = new Vector2(inputX, inputY);
    }
}
