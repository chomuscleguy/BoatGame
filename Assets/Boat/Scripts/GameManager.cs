using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int Score { get; private set; }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(int value)
    {
        Score += value;
    }

}
