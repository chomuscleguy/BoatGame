using UnityEngine;

public class Ship : MonoBehaviour
{
    float originalY;
    void Start()
    {
        originalY = transform.position.y;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * 1.5f) * 0.05f;
        transform.position = new Vector3(transform.position.x, originalY + offset, transform.position.z);
    }
}
