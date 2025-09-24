using System.Drawing;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject Player;

    public int Score { get; private set; }
    public int cnt { get; private set; }

    public int time { get; private set; }
    public int Life { get; private set; }

    private float min;
    private float sec;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        if (Player == null)
            Player = GameObject.FindWithTag("Player");
    }

    private void Start()
    {
        Life = 3;
        UIManager.instance.life.text = $"Life : {Life}";
        min = 0;
        sec = 0;
    }

    private void Update()
    {
        int score = GameManager.instance.Score;
        UIManager.instance.point.text = $"Point : {score}";
        sec += Time.deltaTime;

        if (sec >= 60)
        {
            sec %= 60;
            min++;
        }

        UIManager.instance.time.text = $"{min:00}:{sec:00}";
    }

    public void AddScore(int value)
    {
        Score += value;
    }

    public void AddCnt(int value)
    {
        cnt += value;
    }

    public void ClearCnt()
    {
        cnt = 0;
    }

    public int DecreaseLife()
    {
        if (Life > 1)
        {
            Debug.Log("Hit");
            GameManager.instance.Player.GetComponent<Move>().anim.Stop();
            GameManager.instance.Player.GetComponent<Move>().anim.Play();
            Life--;
        }
        else
        {
            UIManager.instance.endPoint.text = $" Point : {Score}";
            UIManager.instance.endTime.text = $"Time : {min:00} : {sec:00}";
            UIManager.instance.GameOverUI.SetActive(true);
            Time.timeScale = 0;
        }

        return Life;
    }


}
