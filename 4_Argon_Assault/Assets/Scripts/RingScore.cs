using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingScore : MonoBehaviour
{
    [SerializeField] int score = 1000;
    ScoreBoard scoreBoard;
    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }
    private void OnTriggerEnter(Collider other)
    {
        scoreBoard.ScoreHit(score);
    }
}
