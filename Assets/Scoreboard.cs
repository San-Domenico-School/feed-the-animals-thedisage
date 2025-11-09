using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Scoreboard : MonoBehaviour
{
    static public Scoreboard Instance;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI remainingText;
    private int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void UpdateScore(int changeInScore)
    {

    }
    public void UpdateRemaining(int animalsRemaining)
    {
        
    }
    // Update is called once per frame
    private void Awake()
    {
        
    }

}

