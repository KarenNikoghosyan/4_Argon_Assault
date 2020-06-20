using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject deathFX;
    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }
    private void StartDeathSequence()
    {
        gameObject.SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);
        Invoke("ReloadLevel", levelLoadDelay);
    }
    private void ReloadLevel()
    {
        deathFX.SetActive(false);
        SceneManager.LoadScene(1);
    }
}