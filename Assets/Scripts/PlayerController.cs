using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds player state information and logic.
/// </summary>
public class PlayerController : MonoBehaviour
{
    // Store references to these class instances
    GameController gameController;
    WorldController worldController;
    InGameUIController gameUIController;

    // Checkpoint
    private Checkpoint lastCheckpoint = null;
    
    // Movement
    Rigidbody2D rb;
    Vector3 mousePosition;
    Vector3 direction;
    float move;
    float baseSpeed;
    float speed;
    bool sprinting = false;

    // Stats
    int health;
    float stamina;
    float staminaRechargeRate;
    float staminaDrainRate;
    float sprintMultplier;

    // Time check
    public float timer = 1.5f;

    void Awake()
    {
        GameObject engineObj = GameObject.FindGameObjectWithTag("GameController");
        gameController = engineObj.GetComponent<GameController>();
        worldController = engineObj.GetComponent<WorldController>();
        gameUIController = engineObj.GetComponent<InGameUIController>();

        rb = GetComponent<Rigidbody2D>();
    }

    void Start() {
        // Set stats
        baseSpeed = gameController.GetPlayerSpeed();
        sprintMultplier = gameController.GetPlayerSprintMultiplier();
        staminaRechargeRate = gameController.GetPlayerStaminaRechargeRate();
        staminaDrainRate = gameController.GetPlayerStaminaDrainRate();
        ResetStats(); // health and stamina

        // Initial movement
        rb.MovePosition(worldController.GetPlayerStartingLocation());
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        direction = (mousePosition - transform.position).normalized;
        speed = GetCurrentSpeed() * Vector3.Distance(mousePosition, transform.position) * Time.deltaTime;
        rb.MovePosition(transform.position + (direction * speed));
        HandleStamina();
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
        if (otherObj.GetComponent<EnemyController>())
        {
            EnemyController enemy = otherObj.GetComponent<EnemyController>();
            // health -= enemy.GetAttack();
            gameUIController.UpdateHealth(health);
            if (health <= 0) Die();
        }
        
        if (otherObj.GetComponent<InstantTrap>())
        {
            InstantTrap trap = otherObj.GetComponent<InstantTrap>();
            health -= trap.GetDamage();
            if (health <= 0) Die();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        GameObject otherObj = other.gameObject;
        if (otherObj.GetComponent<PoisonTrap>())
        {
            PoisonTrap trap = otherObj.GetComponent<PoisonTrap>();
            health -= trap.GetDamage();
            if (health <= 0) Die();
        }
        if (otherObj.GetComponent<TriggerTrap>())
        {
            TriggerTrap trap = otherObj.GetComponent<TriggerTrap>();
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                health -= trap.GetDamage();
                timer = 1.5f;
            }
            if (health <= 0) Die();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GameObject otherObj = other.gameObject;
        if (otherObj.GetComponent<TriggerTrap>())
        {
            timer = 1.5f;
        }
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

    private float GetCurrentSpeed()
    {
        if (Input.GetMouseButton(0) && CanSprint()) 
        {
            sprinting = true;
            return baseSpeed * sprintMultplier;
        }
        else
        {
            sprinting = false;
            return baseSpeed;
        }
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
}
