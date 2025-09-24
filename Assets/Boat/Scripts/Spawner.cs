using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //private Vector3 spawnAreaSize;
    //public LayerMask playerLayer;

    #region Ray쏘는거
    //private void Start()
    //{
    //    spawnAreaSize = new Vector3(100, 0, 100);

    //    InvokeRepeating("spawn", 0.0f, 3.0f);
    //}

    //void spawn()
    //{
    //    Vector3 spawnPos = GetValidSpawnPosition();

    //    if (spawnPos != Vector3.zero)
    //    {
    //        ObjectPool.instance.GetPoint(spawnPos);
    //        Debug.Log("생성 위치: " + spawnPos);
    //    }
    //    else
    //    {
    //        Debug.Log("플레이어 근처라 생성 못함");
    //    }
    //}

    //Vector3 GetValidSpawnPosition()
    //{
    //    int maxAttempts = 10;

    //    for (int i = 0; i < maxAttempts; i++)
    //    {
    //        Vector3 randomPos = GetRandomPosition();

    //        Ray ray = new Ray(randomPos + Vector3.up * 10f, Vector3.down);
    //        if (Physics.Raycast(ray, out RaycastHit hit, 20f, playerLayer))
    //        {
    //            Debug.Log("플레이어가 있어서 생성 안함");
    //            continue; 
    //        }

    //        return randomPos;
    //    }

    //    return Vector3.zero;
    //}

    //Vector3 GetRandomPosition()
    //{
    //    float x = Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2);
    //    float y = 0;
    //    float z = Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2);

    //    return new Vector3(x, y, z) + transform.position;
    //}
    #endregion
    IEnumerator Start()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(3);
        }
    }

    void Spawn()
    {
        Vector3 spawnPos = GetRanPos();
        ObjectPool.instance.GetPoint(spawnPos);
    }

    Vector3 GetRanPos()
    {
        float diff = 5f;

        Vector3 point = transform.position + Random.insideUnitSphere * 15f;
        point.y = 0;

        float dist = Vector3.Distance(GameManager.instance.Player.transform.position, point);

        if (dist >= diff)
            return point;

        return GetRanPos();
    }
}
