using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Vector3 spawnAreaSize;

    void Start()
    {
        spawnAreaSize = new Vector3(100, 0, 100);

        InvokeRepeating("spawn", 0.0f, 3.0f);
    }

    void spawn()
    {
        Vector3 randomPos = GetRandomPosition();
        ObjectPool.instance.GetPoint(randomPos);
        Debug.Log("»ý¼º");
    }
    Vector3 GetRandomPosition()
    {
        float x = Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2);
        float y = 0;
        float z = Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2);

        return new Vector3(x, y, z) + transform.position;
    }

}
