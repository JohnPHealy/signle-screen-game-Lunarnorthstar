using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private UnityEvent<string> addScore;
    [SerializeField] private UnityEvent<string> lowerCount;
    private Vector3 startPos;
    private int score;
    private int flames;

    private void Start()
    {
        startPos = player.transform.position;
        score = 0;
        flames = 37;
        UpdateUI();
        PauseGame();

    }

    public void RespawnPlayer()
    {
        player.transform.position = startPos;
        //score = 0;
        UpdateUI();
    }

    public void AddScore(int scoreAmt)
    {
        score += scoreAmt;
        UpdateUI();
    }
    public void LowerCount(int flamecounts)
    {
        flames -= flamecounts;
        UpdateUI();
    }

    private void UpdateUI()
    {
        addScore.Invoke(score.ToString());
        lowerCount.Invoke(flames.ToString());
    }

    
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
    }
    
}