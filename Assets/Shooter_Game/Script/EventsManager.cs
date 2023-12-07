using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class EventsManager
{
    public static event Action OnEnemyDiedE;
    public static event Action OnPlayerHitE;
    public static event Action OnPlayerDiedE;

    public static void OnEnemyDied()
    {
        OnEnemyDiedE?.Invoke();
    }

    public static void OnPlayerHit()
    {
        OnPlayerHitE?.Invoke();
    }

    public static void OnPlayerDied()
    {
        OnPlayerDiedE?.Invoke();
    }
}
