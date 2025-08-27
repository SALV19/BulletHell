using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed = 10;
    public float timer = 0.5f;
    public int damage = 10;
    public float delay = 0;


    // Update is called once per frame
    protected virtual void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            BulletCounter.bC.DestroyObject(gameObject);
        }

        if (delay <= 0)
            transform.position += -transform.up * speed * Time.deltaTime;
        else 
            delay -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boss" || collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().Hit(damage);
            BulletCounter.bC.DestroyObject(gameObject);
        }
        else if (collision.gameObject.tag != "BossBullet")
            BulletCounter.bC.DestroyObject(gameObject);
    }

}
