using UnityEngine;

public class Point : MonoBehaviour
{
    public LayerMask playerLayer;
    public int pointValue = 10;

    void OnTriggerEnter(Collider other)
    {
        if ((playerLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            GameManager.instance.AddScore(pointValue);
            ObjectPool.instance.ReturnPoint(this);
            Debug.Log("∏‘¿Ω");
        }
    }
}
