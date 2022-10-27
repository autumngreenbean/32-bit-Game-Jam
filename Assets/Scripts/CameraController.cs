using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameController gameController;
    WorldController worldController;

    Transform t;

    float baseSpeed;
    float minPlayerMultiplier;
    float maxPlayerMultiplier;

    private void Awake() {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        worldController = GameObject.FindGameObjectWithTag("GameController").GetComponent<WorldController>();

        t = gameObject.transform;

        baseSpeed = gameController.GetCameraBaseSpeed();
        minPlayerMultiplier = gameController.GetCameraMinPlayerMultipier();
        maxPlayerMultiplier = gameController.GetCameraMaxPlayerMultipier();

        t.position = worldController.GetCameraStartingLocation();
    }

    private void Update() {
        t.Translate(Vector3.right * GetCameraSpeed() * Time.deltaTime, Space.World);
    }

    private float GetCameraSpeed()
    {
        float playerScreenX = Camera.main.WorldToScreenPoint(worldController.GetPlayerLocation()).x;
        float playerFactor = Utilities.Map(playerScreenX, 0, Camera.main.pixelWidth, minPlayerMultiplier, maxPlayerMultiplier);
        return baseSpeed * playerFactor;
    }

    public void ResetLocation(float xValue)
    {
        t.position = new Vector3(xValue, t.position.y, t.position.z);
    }
}
