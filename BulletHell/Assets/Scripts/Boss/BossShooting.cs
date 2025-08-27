using UnityEngine;
using System.Collections;

public class BossShooting : MonoBehaviour
{
    public GameObject[] bullets;
    public Vector2 direction;
    private Boss boss;
    public int degreesOffset;
    public float maxCooldown = 1.0f;

    private GameObject parent;
    private GameObject fireSpawner;

    private float cooldown = 2.0f;
    private float degrees;

    void Start()
    {
        parent = transform.parent.gameObject;
        boss = parent.GetComponent<Boss>();
        fireSpawner = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        direction = boss.direction;
        transform.up = -direction;

        degrees = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + degreesOffset;
        
        cooldown -= Time.deltaTime;

        if (cooldown <= 0)
        {   
            if (boss.phase == 1) Phase1Attack();
            else if (boss.phase == 2) Phase2Attack();
            else if (boss.phase == 3) Phase3Attack();
            cooldown = maxCooldown;
        }
    }

    private void Phase1Attack()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 randomValues = new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f), 0);
            Instantiate(bullets[0], fireSpawner.transform.position + randomValues, Quaternion.Euler(0, 0, degrees));
        }

    }

    private void Phase2Attack()
    {
        float maxSpanOffset = 100;
        float maxInnerCooldown = 0.2f;

        float spanOffset = maxSpanOffset * -1;
        float innerCooldown = 0;
                
        float offsetChange = 10;

        for (int i = 0; i < 2; i++) 
        {
            if (innerCooldown <= 0) 
            {
                while (spanOffset <= maxSpanOffset)
                {
                    if (innerCooldown <= 0) 
                    {
                        Instantiate(bullets[1], transform.position, Quaternion.Euler(0, 0, degrees + spanOffset));
                        spanOffset += offsetChange;
                        innerCooldown = maxInnerCooldown;
                    }
                    innerCooldown -= Time.deltaTime;
                }
                innerCooldown = maxInnerCooldown/2;
                spanOffset = -1 * maxSpanOffset;
                spanOffset = 5;
            }
            else
                innerCooldown -= Time.deltaTime;
        }

    }

    private void Phase3Attack()
    {

    }
}
