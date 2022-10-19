using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Turns GameObject into checkpoint when attached with Collider and Transform. Will overwrite other collision behavior. 
/// </summary>
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Transform))]
public class Checkpoint : MonoBehaviour
{
    private Vector3 location;
    private bool activated = false;

    private void Awake()
    {
        location = gameObject.transform.position;
    }

    /// <summary>
    /// Returns true if this checkpoint has been activated already. 
    /// </summary>
    public bool IsActivated()
    {
        if (activated) return true;
        return false;
    }

    /// <summary>
    /// Activate the checkpoint, setting the player's respawn location. Cannot be activated again. 
    /// </summary>
    public void Activate()
    {
        if (activated) 
        {
            Debug.Log("Trying to activate checkpoint more than once.");
            return;
        }
        activated = true;
    }

    /// <summary>
    /// Handles respawn of player at checkpoint location. 
    /// </summary>
    public void Respawn(PlayerController player)
    {
        player.gameObject.transform.position = location;
    }
}
