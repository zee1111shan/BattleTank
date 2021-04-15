using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    void Awake()
    {
        current = this;
    }

    public event Action OnGameStateChange;
    public event Action OnHealthChange;
    public void GameStateChange()
    {
        if (OnGameStateChange != null)
        {
            OnGameStateChange();
        }
    }

    public void HealthChange()
    {
        if (OnHealthChange != null)
            OnHealthChange();
    }
}
