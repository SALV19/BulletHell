using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject player;
    public Sprite[] sprites;
    private Rigidbody2D rb;
    public Vector2 direction;
    private SpriteRenderer spriteR;

    public GameObject transition;

    public float baseSpeed = 10;
    public float phase2Multiplier = 1.3f;
    public float phase3Multiplier = 1.5f;

    public int phase = 1;

    private float multiplier = 1f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        spriteR = gameObject.GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        direction = GetPlayerPosition();
        Move(direction);
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
        rb.linearVelocity = direction * baseSpeed * multiplier * Time.deltaTime;
    }

    public void NextPhase()
    {
        phase += 1;
        if (phase == 2)
        {
            multiplier = phase2Multiplier;
            spriteR.sprite = sprites[1];
            InstantiateTransition();
        }
        else if (phase == 3)
        {
            multiplier = phase3Multiplier;
            spriteR.sprite = sprites[2];
            InstantiateTransition();
        }
    }

    public void InstantiateTransition()
    {
        BulletCounter.bC.InstantiateObject(transition, transform);
        GetComponentInChildren<BossShooting>().enabled = false;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        float innerTimer = 1.0f;
        while (innerTimer > 0)
        {
            innerTimer -= Time.deltaTime;
        }
        GetComponentInChildren<BossShooting>().enabled = true;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
    }
}
