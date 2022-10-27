using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides world location values.  
/// </summary>
public class WorldController : MonoBehaviour
{
    // Should only have one WorldController in the scene. (singleton class)
    public static WorldController instance { get; private set; }

    // Store references to these class instances
    PlayerController player;
    CameraController cam;

    // Default starting locations
    [SerializeField] Vector3 playerStartingLocation = new Vector3(0, 0, 0);
    [SerializeField] Vector3 cameraStartingLocation = new Vector3(0, 0, 0);

    // Environment layer Z values
    [SerializeField] float foregroundZ = 0;
    [SerializeField] float midgroundZ = 0;
    [SerializeField] float backgroundZ = 0;
    [SerializeField] float backbackgroundZ = 0;

    /// <summary>
    /// Enumeration of different enviroment layers used to set z-position.
    /// </summary>
    public enum EnvironmentLayers
    {
        Foreground,
        Midground,
        Background,
        BackBackground
    }

    private void Awake() {
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Controller in the scene.");
        }
        instance = this;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
    }

    /// <summary>
    /// Returns the z-value for the associated enviroment layer
    /// </summary>
    /// <param name="layer">The environmet.</param>
    /// <returns>
    /// z-value of the layer.
    /// </returns>
    public float GetLayerZ(EnvironmentLayers layer)
    {
        if (layer == EnvironmentLayers.Foreground) return foregroundZ;
        else if (layer == EnvironmentLayers.Midground) return midgroundZ;
        else if (layer == EnvironmentLayers.Background) return backgroundZ;
        else if (layer == EnvironmentLayers.BackBackground) return backbackgroundZ;
        else return 0;
    }

    /// <summary>
    /// Returns the starting player location.
    /// </summary>
    public Vector3 GetPlayerStartingLocation()
    {
        return playerStartingLocation;
    }

    /// <summary>
    /// Returns the current player location.
    /// </summary>
    public Vector3 GetPlayerLocation()
    {
        return player.GetLocation();
    }

    /// <summary>
    /// Returns the starting camera location.
    /// </summary>
    public Vector3 GetCameraStartingLocation()
    {
        return cameraStartingLocation;
    }

    /// <summary>
    /// Resets the camera x-location.
    /// </summary>
    public void ResetCameraLocation(float xValue)
    {
        cam.ResetLocation(xValue);
    }
}
