using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed = 10;
    public float timer = 0.5f;
    public int damage = 10;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }

        transform.position += -transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with: ", collision);
        if (collision.gameObject.tag == "Boss" || collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().Hit(damage);
        }
        Destroy(gameObject);
    }

}
