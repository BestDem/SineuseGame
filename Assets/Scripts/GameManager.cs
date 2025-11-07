using System;
using UnityEngine;

public static class GameManager
{
    public static bool isPause = false;
    public static bool isPauseDeath = false;
    public static bool delayBeforeStart = true;
    public static event Action OnMovement;
    public static event Action OnDeath;

    public static void TriggerMovement()
    {
        OnMovement?.Invoke();
    }
    public static void TriggerDeath()
    {
        OnDeath?.Invoke();
    }
}
