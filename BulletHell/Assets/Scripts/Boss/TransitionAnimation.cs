using UnityEngine;

public class TransitionAnimation : MonoBehaviour
{
    public float time = 1.0f;
    public Vector3 rotation;
    public Vector3 initialScale = new Vector3(0.1f, 0.1f, 0.1f);
    public Vector3 targetScale = new Vector3(1.5f, 1.5f, 1.5f);
    public float scaleSpeed = 2;
    
    void Start()
    {
        transform.localScale = initialScale;
    }
    // Update is called once per frame
    void Update()
    {
        if (time <0)    
        {
            BulletCounter.bC.DestroyObject(gameObject);
        }
        else
        {   
            time -= Time.deltaTime;
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, scaleSpeed * Time.deltaTime);
            transform.Rotate(rotation * Time.deltaTime);
        }
    }
}


// https://www.youtube.com/watch?v=xk0YFoqXPtI