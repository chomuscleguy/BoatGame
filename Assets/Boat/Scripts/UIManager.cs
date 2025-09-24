using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI point;
    public TextMeshProUGUI time;
    public TextMeshProUGUI life;
    public TextMeshProUGUI endPoint;
    public TextMeshProUGUI endTime;
    public GameObject GameOverUI;

    private void Awake()
    {
        UIManager.instance = this;
    }

    private void Start()
    {

        GameOverUI.SetActive(false);
    }

    

}
