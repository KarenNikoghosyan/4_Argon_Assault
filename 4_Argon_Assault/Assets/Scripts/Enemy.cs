﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 100;
    [SerializeField] int hits = 20;

    ScoreBoard scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hits <= 0)
        {
            EnemyKill();
        }
    }

    private void ProcessHit()
    {
        scoreBoard.ScoreHit(scorePerHit);
        hits--;
    }

    private void EnemyKill()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
