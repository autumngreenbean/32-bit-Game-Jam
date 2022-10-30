using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameUIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI staminaText;

    public void UpdateHealthUI(int health)
    {
        healthText.text = String.Format("Health: {0}", health);
    }

    public void UpdateStaminaUI(float stamina)
    {
        staminaText.text = String.Format("Stamina: {0}", stamina);
    }
}
