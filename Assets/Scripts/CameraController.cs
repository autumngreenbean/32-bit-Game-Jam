using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameController gameController;
    WorldController worldController;

    Transform t;

    float baseSpeed;
    float minPlayerMultiplier;
    float maxPlayerMultiplier;
    bool canMove = false;

    private void Start() {
        worldController = gameController.GetWorldController();

        t = gameObject.transform;

        baseSpeed = gameController.GetCameraBaseSpeed();
        minPlayerMultiplier = gameController.GetCameraMinPlayerMultipier();
        maxPlayerMultiplier = gameController.GetCameraMaxPlayerMultipier();

        t.position = worldController.GetCameraStartingLocation();

        canMove = false;
    }

    private void Update() {
        if (canMove)
        {
            t.Translate(Vector3.right * GetCameraSpeed() * Time.deltaTime, Space.World);
        }
    }

    public void EnableMovement()
    {
        canMove = true;
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
