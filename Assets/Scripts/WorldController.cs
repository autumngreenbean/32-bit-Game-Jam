using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    // Player Z value
    [SerializeField] int playerZ = 0;
    [SerializeField] Vector3 playerInitialSpawn = new Vector3(0, 0, 0);

    // Environment layer Z values
    [SerializeField] int foregroundZ = 0;
    [SerializeField] int midgroundZ = 0;
    [SerializeField] int backgroundZ = 0;
    [SerializeField] int backbackgroundZ = 0;

    public enum EnviromentLayers
    {
        Foreground,
        Midground,
        Background,
        BackBackground
    }

    /// <summary>
    /// Returns the z-value for the associated enviroment layer
    /// </summary>
    public int GetLayerZ(EnviromentLayers layer)
    {
        if (layer == EnviromentLayers.Foreground) return foregroundZ;
        else if (layer == EnviromentLayers.Midground) return midgroundZ;
        else if (layer == EnviromentLayers.Background) return backgroundZ;
        else if (layer == EnviromentLayers.BackBackground) return backbackgroundZ;
        else return 0;
    }
}
