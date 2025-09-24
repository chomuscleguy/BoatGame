using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    [SerializeField] private Point pointPrefab;
    [SerializeField] private int initialSize = 50;

    private Queue<Point> pool = new Queue<Point>();

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
        Point point = Instantiate(pointPrefab, transform);
        point.gameObject.SetActive(false);
        pool.Enqueue(point);
    }

    public Point GetPoint(Vector3 position)
    {
        if (pool.Count == 0) AddCoinToPool();

        Point point = pool.Dequeue();
        point.transform.position = position;
        point.gameObject.SetActive(true);
        return point;
    }

    public void ReturnPoint(Point point)
    {
        point.gameObject.SetActive(false);
        pool.Enqueue(point);
    }
}
