using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrap : MonoBehaviour
{
    // int damage = 40;
    bool triggered = false;

    // public int GetDamage()
    // {
    //     return damage;
    // }

    public void Trigger()
    {
        triggered = true;
    }

    public void Untrigger()
    {
        triggered = false;
    }

    public bool IsTriggered()
    {
        if (triggered) return true;
        return false;
    }
}
