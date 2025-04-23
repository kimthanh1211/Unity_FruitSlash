using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    private int score;
    public static GameManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        score = 0;
        UpdateScore();
    }
    void Update()
    {

    }
    void UpdateScore()
    {
        scoreText.text = $"Score: {score}";
    }
    public void IncreaseScore()
    {
        score++;
        UpdateScore();
    }

}
