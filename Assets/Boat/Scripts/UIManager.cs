using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI point;
    public TextMeshProUGUI time;
    public TextMeshProUGUI life;

    private float min;
    private float sec;
    private void Start()
    {
        min = 0;
        sec = 0;
    }

    private void Update()
    {
        int score = GameManager.instance.Score;
        point.text = $"Point : {score:000}";
        sec += Time.deltaTime;
        if(sec>=60)
        {
            sec %= 60;
            min++;
        }

        time.text = $"{min:00}:{sec:00}";
    }

}
