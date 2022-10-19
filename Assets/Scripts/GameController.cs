using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main controller for gameplay logic and game state information. 
/// </summary>
public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }

    // Default spawn location, must have a checkpoint component
    [SerializeField] GameObject spawnObj;

    // Checkpoint
    private Checkpoint lastCheckpoint;

    // Player
    [SerializeField] GameObject playerObj;
    PlayerController player;
    private int playerHealth = 100;
    // private int playerStamina = 100; commented for now to avoid compiler warning

    private void Awake()
    {
        // Should only have one GameController in the scene. (singleton class)
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Controller in the scene.");
        }
        instance = this;
        
        player = playerObj.GetComponent<PlayerController>();

        // set default spawn
        lastCheckpoint = spawnObj.GetComponent<Checkpoint>();
    }

    /// <summary>
    /// Called when player collides with a checkpoint or enemy.
    /// </summary>
    public void OnPlayerCollision(GameObject other)
    {
        if (other.GetComponent<Checkpoint>())
        {
            Checkpoint point = other.GetComponent<Checkpoint>();
            if (!point.IsActivated()) 
            {
                lastCheckpoint = point;
                point.Activate();
            }
        }
        if (other.GetComponent<EnemyController>())
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            // playerHealth -= enemy.attack;
            if (playerHealth <= 0)
            {
                OnPlayerDeath();
            } 
        }
    } 

    /// <summary>
    /// Called when player's health falls below zero.
    /// </summary>
    public void OnPlayerDeath()
    {
        lastCheckpoint.Respawn(player);
        return;
    }
}
