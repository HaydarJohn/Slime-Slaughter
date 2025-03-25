using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float lifeTime = 2f;  // Time in seconds before bullet is destroyed

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
