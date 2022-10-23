using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main controller for gameplay logic and game state information. 
/// </summary>
public class GameController : MonoBehaviour
{
    // Should only have one GameController in the scene. (singleton class)
    public static GameController instance { get; private set; }
    
    public WorldController worldController;

    // Player
    [SerializeField] int playerMaxHealth = 100;
    [SerializeField] float playerBaseSpeed = 0.1f;
    [SerializeField] float playerSprintMultiplier = 0.1f;
    [SerializeField] float playerMaxStamina = 100f;
    [SerializeField] float playerStaminaDrainRate = 1f;
    [SerializeField] float playerStaminaRechargeRate = 1f;

    // Camera
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

    public float GetPlayerSpeed()
    {
        return playerBaseSpeed;
    }

    public float GetCameraBaseSpeed()
    {
        return cameraBaseSpeed;
    }

    public float GetPlayerSprintMultiplier()
    {
        return playerSprintMultiplier;
    }

    public float GetCameraMinPlayerMultipier()
    {
        return cameraPlayerMinMultiplier;
    }

    public float GetCameraMaxPlayerMultipier()
    {
        return cameraPlayerMaxMultiplier;
    }

    public int GetPlayerMaxHealth()
    {
        return playerMaxHealth;
    }

    public float GetPlayerMaxStamina()
    {
        return playerMaxStamina;
    }

    public float GetPlayerStaminaRechargeRate()
    {
        return playerStaminaRechargeRate;
    }

    public float GetPlayerStaminaDrainRate()
    {
        return playerStaminaDrainRate;
    }
}
