using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    // Should only have one WorldController in the scene. (singleton class)
    public static WorldController instance { get; private set; }

    PlayerController player;

    [SerializeField] Vector3 playerStartingLocation = new Vector3(0, 0, 0);
    [SerializeField] Vector3 cameraStartingPosition = new Vector3(0, 0, 0);

    // Environment layer Z values
    [SerializeField] float foregroundZ = 0;
    [SerializeField] float midgroundZ = 0;
    [SerializeField] float backgroundZ = 0;
    [SerializeField] float backbackgroundZ = 0;

    public enum EnviromentLayers
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
    }

    /// <summary>
    /// Returns the z-value for the associated enviroment layer
    /// </summary>
    public float GetLayerZ(EnviromentLayers layer)
    {
        if (layer == EnviromentLayers.Foreground) return foregroundZ;
        else if (layer == EnviromentLayers.Midground) return midgroundZ;
        else if (layer == EnviromentLayers.Background) return backgroundZ;
        else if (layer == EnviromentLayers.BackBackground) return backbackgroundZ;
        else return 0;
    }

    public Vector3 GetPlayerStartingLocation()
    {
        return playerStartingLocation;
    }

    public Vector3 GetPlayerLocation()
    {
        return player.GetLocation();
    }

    public void RespawnPlayer(Checkpoint checkpoint)
    {
    }

    public Vector3 GetCameraStartingLocation()
    {
        return cameraStartingPosition;
    }
}
