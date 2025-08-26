using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;

    public float baseSpeed = 10;
    public float phase2Multiplier = 1.3f;
    public float phase3Multiplier = 1.5f;
    public float maxCooldown = 1.0f;

    public int phase = 1;

    public float life = 100f;

    private float cooldown = 2.0f;
    private bool notAttacking = true;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (notAttacking) 
        {
            Vector2 direction = GetPlayerPosition();
            Move(direction);
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                cooldown = maxCooldown;
            }
        }
    }

    Vector2 GetPlayerPosition()
    {
        float x = player.transform.position.x - transform.position.x;
        float y = player.transform.position.y - transform.position.y;

        Vector2 direction = new Vector2(x, y);
        return direction;
    }

    private void Move(Vector2 direction)
    {
        rb.linearVelocity = direction * baseSpeed * Time.deltaTime;
    }
}
