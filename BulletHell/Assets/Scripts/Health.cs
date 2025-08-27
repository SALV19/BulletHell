using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    public float threashold = 0.5f;
    public int health;
    
    void Start()
    {
        health = maxHealth;
    }
    
    public void Hit(int damage)
    {
        health -= damage;
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
                bossScript.NextPhase();
                threashold = 0.2f;
            }
        }
    }
}
