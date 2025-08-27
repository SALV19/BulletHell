using UnityEngine;
using System.Collections;
using TMPro;

public class BulletCounter : MonoBehaviour
{
    public static BulletCounter bC;
    private int bullets;
    private TMP_Text text;

    private void Awake()
    {
        if (bC != null && bC != this) 
        {
            Destroy(this);
        }
        else
        {
            bC = this;
            text = GetComponent<TMP_Text>();
        } 
    }

    public GameObject InstantiateObject(GameObject instance, Transform position)
    {
        GameObject createdObject = Instantiate(instance, position) as GameObject;
        HandleInstance();
        return createdObject;
    }

    public GameObject InstantiateObject(GameObject instance, Vector3 position, Quaternion rotation)
    {
        GameObject createdObject = Instantiate(instance, position, rotation) as GameObject;
        HandleInstance();
        return createdObject;
    }

    private void HandleInstance()
    {
        bullets++;
        UpdateUI();
    }

    public void DestroyObject(GameObject m_object)
    {
        Destroy(m_object);
        bullets--;
        UpdateUI();
    }

    private void UpdateUI()
    {
        text.text = $"Bullet Counter: {bullets}";
    }

}


// https://refactoring.guru/es/design-patterns/singleton/csharp/example
// https://gamedevbeginner.com/singletons-in-unity-the-right-way/