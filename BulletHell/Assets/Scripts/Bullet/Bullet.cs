using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed = 10;
    public float timer = 0.5f;

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

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

}
