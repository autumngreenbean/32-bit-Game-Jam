using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExitText : MonoBehaviour
{
    TextMeshProUGUI guiText;
    float speed = 0.75f;

    void Start() 
    {
        guiText = gameObject.GetComponent<TextMeshProUGUI>();    
    }
    void Update() {

        guiText.alpha = Mathf.PingPong(Time.time * speed, 1.0f);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Exited the App!");
            Application.Quit();
        }
    }
}
