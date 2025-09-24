using UnityEngine;

public class LateFollowCam : MonoBehaviour
{
    public Transform target;         
    public float smoothSpeed = 5f;   
    public Vector3 offset;

    private void Start()
    {
        offset = transform.position;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
