using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;

    // Update is called once per frame
    void LateUpdate()
    {
        if (!boss) 
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        }
        else 
        {
            Vector3 midPoint = (player.transform.position + boss.transform.position) / 2f;
            transform.position = new Vector3(midPoint.x, midPoint.y, -10);
        }
    }
}
