using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] TMP_Text Score;

    public void IncrementScore(int IncrementBy)
    {
        score += IncrementBy;
        this.Score.text = score.ToString();
    }
}
