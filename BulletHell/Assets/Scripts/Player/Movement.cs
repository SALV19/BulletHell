using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;
    private Vector2 movementInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        movementInput = new Vector2(horizontal, vertical);
        movementInput.Normalize();

        rb.linearVelocity = movementInput * speed;
    }
}
