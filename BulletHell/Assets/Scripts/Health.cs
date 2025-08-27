using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    public float threashold = 0.6f;
    private float health;
    public float defense = 0.0f;
    public int phases = 3;

    private IEnumerator coroutine;
    
    void Start()
    {
        health = maxHealth;
    }
    
    public void Hit(int damage)
    {
        health -= damage - damage * defense;
        SpriteRenderer spriteR = gameObject.GetComponent<SpriteRenderer>();
        spriteR.color = Color.red;
        StartCoroutine(ColorChange(spriteR));

        if (health <= 0) 
        {
            Destroy(gameObject);
            return;
        }

        if (gameObject.tag == "Boss")
        {
            Boss bossScript = gameObject.GetComponent<Boss>();
            if (health <= maxHealth * threashold) 
            {
                if (phases == 3) 
                {
                    phases--;
                    defense += 0.3f;
                    threashold = 0.3f;
                    bossScript.NextPhase();
                }
                else if (phases == 2) 
                {
                    phases--;
                    defense += 0.3f;
                    bossScript.NextPhase();
                }
            }
        }
    }

    IEnumerator ColorChange(SpriteRenderer spriteR)
    {
        yield return new WaitForSeconds(0.2f);
        spriteR.color = Color.white;
    }
}
