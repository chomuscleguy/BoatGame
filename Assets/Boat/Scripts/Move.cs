using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //public GameObject ground;
    private Rigidbody rb;
    //public float force;
    //public bool isGround;
    public float speed = 5;
    public float angle = 180;
    private ParticleSystem spray;
    public GameObject tail;
    public RectTransform handle;
    public Animation anim;

    public List<GameObject> tailList;


    private Vector3 velocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        spray = GetComponentInChildren<ParticleSystem>();
        tailList = new List<GameObject>();
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

        Vector3 handleAngles =  handle.localEulerAngles;
        handleAngles.z += h; 
        handle.localEulerAngles = handleAngles;

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

    GameObject lastTail;

    public void InstancePoint()
    {
        if (lastTail == null)
            lastTail = transform.GetChild(0).gameObject;

        GameObject obj = Instantiate(tail, lastTail.transform.position, Quaternion.identity);

        int speed = Mathf.Max(1, 10 - GameManager.instance.cnt);

        obj.GetComponent<Tail>().SetInfo(lastTail, speed);

        lastTail = obj;
        tailList.Add(obj);
    }
}
