using Unity.VisualScripting;
using UnityEngine;

public class ClearZone : MonoBehaviour
{
    public GameObject storage;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameManager.instance.AddScore(GameManager.instance.cnt * 10);
            GameManager.instance.ClearCnt();

            foreach (GameObject obj in GameManager.instance.Player.GetComponent<Move>().tailList)
            {
                obj.GetComponent<Tail>().StartCoroutine(obj.GetComponent<Tail>().IEDestroy(transform, 2.0f, 8.0f));
            }

            GameManager.instance.Player.GetComponent<Move>().tailList.Clear();

            filledStorage(GameManager.instance.Score / 30);
        }

        void filledStorage(int value)
        {
            storage.transform.GetChild(value).gameObject.SetActive(true);
        }
    }
}
