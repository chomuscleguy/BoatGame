using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.ParticleSystem;

public class Move : MonoBehaviour
{
    //public GameObject ground;
    private Rigidbody rb;
    //public float force;
    //public bool isGround;
    public float speed = 5;
    public float angle = 180;
    private ParticleSystem spray;

    private Vector3 velocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        spray = GetComponentInChildren<ParticleSystem>();
    }

    void Start()
    {

    }

    void Update()
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y * Mathf.Sin(Time.deltaTime * 5), transform.position.z);
        //isGround = Physics.CheckSphere(ground.transform.position, 0.2f);

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = transform.forward * v;

        if (dir.magnitude > 1)
            dir = dir.normalized;

        velocity += dir * speed * Time.deltaTime;

        //transform.Rotate(Vector3.up, h * angle * Time.deltaTime);

        //transform.position += velocity * Time.deltaTime;

        rb.MovePosition(rb.transform.position + velocity * Time.deltaTime);

        Quaternion q = Quaternion.Euler(Vector3.up * h * angle * Time.deltaTime);

        rb.MoveRotation(rb.transform.rotation * q);

        velocity = Vector3.Lerp(velocity, Vector3.zero, Time.deltaTime * 6);


        if (velocity.magnitude >= 1)
        {
            if (!spray.isPlaying)
            {
                spray.Play();
            }
        }
        else
        {
            if (spray.isPlaying)
            {
                spray.Stop();
            }
        }

        
    }


}
