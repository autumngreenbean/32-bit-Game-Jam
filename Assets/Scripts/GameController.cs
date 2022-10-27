using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides gameplay values.  
/// </summary>
public class GameController : MonoBehaviour
{
    // Should only have one GameController in the scene. (singleton class)
    public static GameController instance { get; private set; }
    
    // Store references to these class instances
    public WorldController worldController;

    // Player default stats
    [SerializeField] int playerMaxHealth = 100;
    [SerializeField] float playerBaseSpeed = 0.1f;
    [SerializeField] float playerSprintMultiplier = 0.1f;
    [SerializeField] float playerMaxStamina = 100f;
    [SerializeField] float playerStaminaDrainRate = 1f;
    [SerializeField] float playerStaminaRechargeRate = 1f;

    // Camera default stats
    [SerializeField] float cameraBaseSpeed = 0.1f;
    [SerializeField] float cameraPlayerMinMultiplier = 0.2f;
    [SerializeField] float cameraPlayerMaxMultiplier = 1.2f;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Controller in the scene.");
        }
        instance = this;
        
        worldController = gameObject.GetComponent<WorldController>();
    }

    /// <summary>
    /// Returns the default player speed.
    /// </summary>
    public float GetPlayerSpeed()
    {
        return playerBaseSpeed;
    }

    /// <summary>
    /// Returns the default player speed.
    /// </summary>
    public float GetCameraBaseSpeed()
    {
        return cameraBaseSpeed;
    }

    /// <summary>
    /// Returns the player "sprint" speed multiplier.
    /// </summary>
    public float GetPlayerSprintMultiplier()
    {
        return playerSprintMultiplier;
    }

    /// <summary>
    /// Returns the minimum speed multplier caused by the player's position.
    /// </summary>
    public float GetCameraMinPlayerMultipier()
    {
        return cameraPlayerMinMultiplier;
    }

    /// <summary>
    /// Returns the maximum speed multplier caused by the player's position.
    /// </summary>
    public float GetCameraMaxPlayerMultipier()
    {
        return cameraPlayerMaxMultiplier;
    }

    /// <summary>
    /// Returns the player's default maximum health.
    /// </summary>
    public int GetPlayerMaxHealth()
    {
        return playerMaxHealth;
    }

    /// <summary>
    /// Returns the player's default maximum stamina.
    /// </summary>
    public float GetPlayerMaxStamina()
    {
        return playerMaxStamina;
    }

    /// <summary>
    /// Returns the player's default stamina recharge rate.
    /// </summary>
    public float GetPlayerStaminaRechargeRate()
    {
        return playerStaminaRechargeRate;
    }

    /// <summary>
    /// Returns the player's default stamina drain rate.
    /// </summary>
    public float GetPlayerStaminaDrainRate()
    {
        return playerStaminaDrainRate;
    }
}
