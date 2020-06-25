using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    int totalScore;
    Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = totalScore.ToString();
    }
    public void ScoreHit(int score)
    {
        totalScore = totalScore + score;
        scoreText.text = totalScore.ToString();
    }
}
