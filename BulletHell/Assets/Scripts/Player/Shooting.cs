using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public float maxDelay = 0.5f;
    private float delay = 0.0f;
    public int degreesOffset = 90;
    public Camera mainCamera;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

        float x = mousePosition.x - transform.position.x;
        float y = mousePosition.y - transform.position.y;

        Vector2 direction = new Vector2(x, y);
        transform.up = direction;

        float degrees = Mathf.Atan2(y, x) * Mathf.Rad2Deg + degreesOffset;

        if (Input.GetMouseButton(0) && delay <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, degrees));
            delay = maxDelay;
        }

        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }
    }
}
