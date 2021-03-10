using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Collider2D playerCheck;
    [SerializeField] private LayerMask playerLayers;
    [SerializeField] private GameManager manager;
    [SerializeField] private int scoreToGive = 100;


    private void Update()
    {
        if (playerCheck.IsTouchingLayers(playerLayers))
        {
            manager.AddScore(scoreToGive);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            manager.RespawnPlayer();
        }
    }
}