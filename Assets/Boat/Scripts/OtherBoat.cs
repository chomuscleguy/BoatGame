using UnityEngine;

public class OtherBoat : MonoBehaviour
{
    public float speed = 5.0f;
    Vector3 dir;

    void Start()
    {
        GameObject player = GameManager.instance.Player;

        int rand = Random.Range(0, 10);

        if (rand < 3)
        {
            dir = player.transform.position - this.transform.position;
            dir.Normalize();
            transform.forward = dir;
        }
        else
            dir = transform.forward;
    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if(other.attachedRigidbody.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                UIManager.instance.life.text = $"Life : {GameManager.instance.DecreaseLife()}";
            }
        }

    }
}
