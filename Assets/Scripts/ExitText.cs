using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExitText : MonoBehaviour
{
    TextMeshPro guiText;
    float speed = 5.0f;

    void Start() 
    {
        guiText = gameObject.GetComponent<TextMeshPro>();    
    }
    void Update() {

        guiText.alpha = Mathf.PingPong(Time.time * speed, 1.0f);
        // guiText.color.a = Mathf.PingPong(Time.time * speed, 1.0);
    }
}
