using UnityEngine;

public class Dock : MonoBehaviour
{
    public Transform[] spawnPoint;
    float curTime;
    public float makeTime = 2f;
    public GameObject boatFactory;

    int prevIdex;

    void Start()
    {

    }

    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime > makeTime)
        {
            curTime = 0;
            int index = Random.Range(0, spawnPoint.Length);

            // 만약 이전에 만든 위치라면 다른 위치로 정하고싶다.
            if (index == prevIdex)
            {
                index++;
                if (index > spawnPoint.Length - 1)
                {
                    index = 0;
                }
            }

            Transform t = spawnPoint[index].transform;
            Instantiate(boatFactory, t.position, t.rotation);

            prevIdex = index;
        }
    }
}



