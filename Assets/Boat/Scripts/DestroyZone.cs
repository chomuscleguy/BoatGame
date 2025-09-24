using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody)
        {
            Destroy(other.attachedRigidbody.gameObject);
            Debug.Log("�ı�");
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
