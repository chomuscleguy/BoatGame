using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    [SerializeField] private GameObject pointPrefab;
    [SerializeField] private int initialSize = 50;

    private Queue<GameObject> pool = new Queue<GameObject>();

    void Awake()
    {
        instance = this;

        for (int i = 0; i < initialSize; i++)
        {
            AddCoinToPool();
        }
    }

    private void AddCoinToPool()
    {
        GameObject point = Instantiate(pointPrefab, transform);
        point.gameObject.SetActive(false);
        pool.Enqueue(point);
    }

    public GameObject GetPoint(Vector3 position)
    {
        if (pool.Count == 0) AddCoinToPool();

        GameObject point = pool.Dequeue();
        point.transform.position = position;
        point.gameObject.SetActive(true);
        return point;
    }

    public void ReturnPoint(GameObject point)
    {
        point.gameObject.SetActive(false);
        pool.Enqueue(point);
    }
}
