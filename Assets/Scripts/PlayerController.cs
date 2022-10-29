using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds player state information and logic.
/// </summary>
public class PlayerController : MonoBehaviour
{
    // Store references to these class instances
    [SerializeField] GameController gameController;
    WorldController worldController;
    InGameUIController gameUIController;

    // Checkpoint
    private Checkpoint lastCheckpoint = null;
    
    // Movement
    [SerializeField] Transform followPoint;
    Rigidbody2D rb;
    Vector3 move = Vector3.zero;
    bool sprinting = false;
    bool canMove = false;

    // Stats
    float baseSpeed;
    float maxMoveDistance;
    int health;
    float stamina;
    float staminaRechargeRate;
    float staminaDrainRate;
    float sprintMultplier;
    float distanceMultiplier;

    // Trap
    float trapTimer;
    float poisonTick;
    
    void Start() {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        worldController = gameController.GetWorldController();
        // gameUIController = gameController.GetGameUIController();

        rb = GetComponent<Rigidbody2D>();

        canMove = false;

        // Set stats
        baseSpeed = gameController.GetPlayerBaseSpeed();
        maxMoveDistance = gameController.GetPlayerMaxMoveDistance();
        sprintMultplier = gameController.GetPlayerSprintMultiplier();
        distanceMultiplier = gameController.GetPlayerDistanceMultiplier();
        staminaRechargeRate = gameController.GetPlayerStaminaRechargeRate();
        staminaDrainRate = gameController.GetPlayerStaminaDrainRate();
        ResetStats(); // health and stamina

        // Initial movement
        rb.MovePosition(worldController.GetPlayerStartingLocation());

        // Hide cursor
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateFollowPosition();
        HandleStamina();
    }

    private void FixedUpdate()
    {
        rb.AddForce(move * GetCurrentSpeed());
    }

    private void UpdateFollowPosition()
    {
        // If we can't move, dont do anything
        if (!canMove) return;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        followPoint.position = new Vector3(mousePosition.x, mousePosition.y, followPoint.position.z);
        mousePosition = new Vector3(mousePosition.x - 1f, mousePosition.y, 0);

        // get difference from mouse (with distance multiplier and max magnitude)
        move = Vector2.ClampMagnitude((mousePosition - transform.position) * distanceMultiplier, maxMoveDistance);
    }
    private float GetCurrentSpeed()
    {
        float speed = baseSpeed;
        if (Input.GetMouseButton(0) && CanSprint()) 
        {
            sprinting = true;
            speed *= sprintMultplier;
        }
        else sprinting = false;

        return speed * Time.fixedDeltaTime;
    }


    private void OnTriggerEnter2D(Collider2D other) {
        GameObject otherObj = other.gameObject;
        if (otherObj.GetComponent<Checkpoint>())
        {
            Checkpoint point = otherObj.GetComponent<Checkpoint>();
            if (!point.IsActivated()) 
            {
                lastCheckpoint = point;
                point.Activate();
            }
        }
        else if (otherObj.GetComponent<EnemyController>())
        {
            EnemyController enemy = otherObj.GetComponent<EnemyController>();
            TakeDamage();
        }
        else if (otherObj.GetComponent<InstantTrap>())
        {
            InstantTrap trap = otherObj.GetComponent<InstantTrap>();
            TakeDamage();
        }
        else if (otherObj.GetComponent<TriggerTrap>())
        {
            TriggerTrap trap = otherObj.GetComponent<TriggerTrap>();
            if (trap.IsTriggered()) return;
            trapTimer = gameController.GetTriggerTrapTimer();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        GameObject otherObj = other.gameObject;
        if (otherObj.GetComponent<PoisonTrap>())
        {
            PoisonTrap trap = otherObj.GetComponent<PoisonTrap>();
            poisonTick -= Time.deltaTime;
            if (poisonTick <= 0)
            {
                poisonTick = gameController.GetPoisonTickTimer(); 
                TakeDamage();
            }
        }
        else if (otherObj.GetComponent<TriggerTrap>())
        {
            TriggerTrap trap = otherObj.GetComponent<TriggerTrap>();
            trapTimer -= Time.deltaTime;
            if (trapTimer <= 0) TakeDamage();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GameObject otherObj = other.gameObject;
        if (otherObj.GetComponent<TriggerTrap>())
        {
            TriggerTrap trap = otherObj.GetComponent<TriggerTrap>();
            trap.Untrigger();
            trapTimer = gameController.GetTriggerTrapTimer();
        }
        else if (otherObj.GetComponent<PoisonTrap>())
        {
            poisonTick = gameController.GetPoisonTickTimer();
        }
    }

    public void EnableMovement()
    {
        canMove = true;
    }

    /// <summary>
    /// Handles logic after player death.
    /// </summary>
    private void Die()
    {
        // If we have activated a checkpoint, reset the camera there.
        if (lastCheckpoint is not null)
        {
            worldController.ResetCameraLocation(lastCheckpoint.GetLocation().x);
        }
        else worldController.ResetCameraLocation(worldController.GetCameraStartingLocation().x);
        ResetStats();
        Respawn();
    }

    /// <summary>
    /// Resets player location based on the last activated checkpoint, or the default starting location
    /// </summary>
    private void Respawn()
    {
        if (lastCheckpoint is null) SetLocation(worldController.GetPlayerStartingLocation());
        else
        {
            Vector3 checkpointLocation = lastCheckpoint.GetLocation();
            SetLocation(new Vector3(checkpointLocation.x, checkpointLocation.y, worldController.GetPlayerStartingLocation().z));
        }
    }

    public void ResetStats()
    {
        health = gameController.GetPlayerMaxHealth();
        stamina = gameController.GetPlayerMaxStamina();
    }

    public Vector2 GetLocation()
    {
        return rb.position;
    }

    public void SetLocation(Vector3 location)
    {
        rb.position = location;
    }

    private void HandleStamina()
    {
        if (sprinting && stamina > 0) stamina -= (staminaDrainRate * Time.deltaTime);
        else if (stamina < 100) stamina += (staminaRechargeRate * Time.deltaTime);
    }

    private bool CanSprint()
    {
        if (stamina > 0) return true;
        return false;
    }

    private void TakeDamage()
    {
        health -= 1;
        // gameUIController.UpdateHealth(health);
        if (health <= 0) Die();
    }
}
