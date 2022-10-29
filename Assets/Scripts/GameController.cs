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
    [SerializeField] WorldController worldController;
    [SerializeField] PlayerController playerController;
    [SerializeField] CameraController cameraController;
    [SerializeField] InGameUIController gameUIController;

    // Game Stats
    [Header("Game Settings")]
    [SerializeField] float timeToStart = 5.0f;

    // Camera default stats
    [Header("Camera Settings")]
    [SerializeField] float cameraBaseSpeed = 0.1f;
    [SerializeField] float cameraPlayerMinMultiplier = 0.2f;
    [SerializeField] float cameraPlayerMaxMultiplier = 1.2f;

    // Player default stats
    [Header("Player Settings")]
    [SerializeField] int playerMaxHealth = 100;
    [SerializeField] float playerBaseSpeed = 0.1f;
    [SerializeField] float playerMaxMoveDistance = 3.0f;
    [SerializeField] float playerSprintMultiplier = 0.1f;
    [SerializeField] float playerDistanceMultiplier = 0.1f;
    [SerializeField] float playerMaxStamina = 100f;
    [SerializeField] float playerStaminaDrainRate = 1f;
    [SerializeField] float playerStaminaRechargeRate = 1f;

    [Header("Enemy Settings")]
    [SerializeField] float triggerTrapTimer = 1.5f;
    [SerializeField] float poisonTrapTickTimer = 0.5f;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Controller in the scene.");
        }
        instance = this;
    }

    private void Start() {
        
        StartCoroutine(StartGame());
    }

    public WorldController GetWorldController()
    {
        return worldController;
    }

    public PlayerController GetPlayerController()
    {
        return playerController;
    }

    public CameraController GetCameraController()
    {
        return cameraController;
    }

    public InGameUIController GetGameUIController()
    {
        return gameUIController;
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(timeToStart);

        playerController.EnableMovement();
        cameraController.EnableMovement();
    }

    /// <summary>
    /// Returns the default player speed.
    /// </summary>
    public float GetPlayerBaseSpeed()
    {
        return playerBaseSpeed;
    }

    /// <summary>
    /// Returns the max player speed.
    /// </summary>
    public float GetPlayerMaxMoveDistance()
    {
        return playerMaxMoveDistance;
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
    /// Returns the player mouse distance speed multiplier.
    /// </summary>
    public float GetPlayerDistanceMultiplier()
    {
        return playerDistanceMultiplier;
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

    /// <summary>
    /// Returns the trigger trap timer.
    /// </summary>
    public float GetTriggerTrapTimer()
    {
        return triggerTrapTimer;
    }

    /// <summary>
    /// Returns the time between poison damage
    /// </summary>
    public float GetPoisonTickTimer()
    {
        return triggerTrapTimer;
    }
}
