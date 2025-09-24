using UnityEngine;

public class ChangeView : MonoBehaviour
{
    public Camera[] Cam;
    public GameObject minimap;
    public GameObject handle;

    private int currentCamIndex = 0;

    void Start()
    {
        for (int i = 0; i < Cam.Length; i++)
            Cam[i].gameObject.SetActive(i == currentCamIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            currentCamIndex = (currentCamIndex + 1) % Cam.Length;
            changeView(currentCamIndex);
        }
    }

    void changeView(int index)
    {
        for (int i = 0; i < Cam.Length; i++)
            Cam[i].gameObject.SetActive(i == index);
    }
}
