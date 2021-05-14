using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{

    [SerializeField]
    [Range(0f, 5f)]
    float gameSpeed = 1f;

    [SerializeField]
    TextMeshProUGUI scoreText;

    [SerializeField]
    int gameScore = 0;
    int pointsPerBlock = 83;

    void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        scoreText.text = gameScore.ToString();
    }
    public void IncrementGameScore() {
        gameScore += pointsPerBlock;
    }

    public void ResetScore() {
        Destroy(gameObject);
    }
}
