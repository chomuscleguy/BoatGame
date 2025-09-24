using System.Collections;
using UnityEngine;

public class Tail : MonoBehaviour
{
    public int speed = 5;
    public GameObject target;

    void Start()
    {
        transform.position = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 dir = target.transform.position - transform.position/* + new Vector3(0.5f,0,0f)*/;
        dir.Normalize();

        transform.position += dir * speed * Time.deltaTime;
    }

    public void SetInfo(GameObject t, int s)
    {
        target = t;
        speed = s;
    }


    public IEnumerator IEDestroy(Transform target, float duration, float height)
    {
        Vector3 start = transform.position;
        Vector3 end = target.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            Vector3 linear = Vector3.Lerp(start, end, t);

            float parabolaY = Mathf.Sin(Mathf.PI * t) * height;

            transform.position = new Vector3(linear.x,linear.y + parabolaY,linear.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = end;

        yield return null;
        Destroy(gameObject);
    }

}
