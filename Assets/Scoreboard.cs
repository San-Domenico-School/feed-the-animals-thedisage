using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Scoreboard : MonoBehaviour
{
    static public Scoreboard Instance;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI animalsRemainingText;
    private int score;
    private int animalsRemaining = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void UpdateScore(int changeInScore)
    {
        score += changeInScore;
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }

    }
    public void UpdateRemaining()
    {
        animalsRemaining--;
        if (animalsRemainingText != null)
        {
            animalsRemainingText.text = "Remaining: " + animalsRemaining.ToString();
        }
    }
}


