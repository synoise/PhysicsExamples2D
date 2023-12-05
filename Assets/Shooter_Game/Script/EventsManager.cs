using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class EventsManager
{
    public static event Action OnEnemyDiedE;

    public static void OnEnemyDied()
    {
        OnEnemyDiedE?.Invoke();
    }
}
