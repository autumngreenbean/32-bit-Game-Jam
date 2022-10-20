using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    // Player Z value
    [SerializeField] int playerZ = 0;
    [SerializeField] Vector3 playerInitialSpawn = new Vector3(0, 0, 0);

    // Environment layer Z values
    [SerializeField] int foregroundZ = 0;
    [SerializeField] int midgroundZ = 0;
    [SerializeField] int backgroundZ = 0;
    [SerializeField] int backbackgroundZ = 0;
}
