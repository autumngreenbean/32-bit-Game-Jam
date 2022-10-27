using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    [SerializeField] WorldController.EnvironmentLayers layer; 

    private void Awake() {

        Transform transform = gameObject.transform;
        // transform.position = new Vector3(transform.position.x, transform.position.y, WorldController.G     
    }
}
