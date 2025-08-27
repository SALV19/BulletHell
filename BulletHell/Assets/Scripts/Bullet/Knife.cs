using System.Collections;
using UnityEngine;

public class Knife : Bullet
{
    public GameObject player;
    public float offset = 90;

    protected new void Update()
    {
        if (delay >= 0)
        {
          float x = player.transform.position.x - transform.position.x;
          float y = player.transform.position.y - transform.position.y; 

          float degrees = Mathf.Atan2(y, x) * Mathf.Rad2Deg + offset;


          Quaternion target = Quaternion.Euler(0, 0, degrees);

          transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 180f);
        }
        base.Update();
    }
}