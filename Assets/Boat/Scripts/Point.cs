using UnityEngine;

public class Point : MonoBehaviour
{
    public LayerMask playerLayer;
    public int pointValue = 1;

    void OnTriggerEnter(Collider other)
    {
        if ((playerLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            if(GameManager.instance.cnt <10)
            {
                ObjectPool.instance.ReturnPoint(this.gameObject);
                GameManager.instance.AddCnt(pointValue);

                //Transform bodyParent = GameManager.instance.Player.GetComponent<Move>().tail.gameObject.transform;

                //for (int i = 0; i < bodyParent.childCount; i++)
                //{
                //    GameObject child = bodyParent.GetChild(i).gameObject;
                //    if (!child.activeSelf)
                //    {
                //        child.SetActive(true);
                //        break;
                //    }
                //}
                GameManager.instance.Player.GetComponent<Move>().InstancePoint();
                Debug.Log("∏‘¿Ω");
            }
        }
    }
}
