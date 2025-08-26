using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public int health = 10;
    
    public void Hit(int damage)
    {
        health -= damage;
        if (health <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
