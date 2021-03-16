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
    [SerializeField] private int flamecount = 1;
    [SerializeField] private bool IsLava;

    private void Update()
    {
        if (playerCheck.IsTouchingLayers(playerLayers))
        {
            manager.AddScore(scoreToGive);
            
            if (IsLava == false)
            {
                manager.LowerCount(flamecount);
                Destroy(gameObject);
            }
            if (IsLava == true)
            {
                manager.RespawnPlayer();
            }
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