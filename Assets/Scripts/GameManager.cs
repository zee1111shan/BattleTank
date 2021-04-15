using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameState _currentState;

    public static GameManager current;
    
    public GameState CurrentState
    {
        get
        {
            return _currentState;
        }
        set
        {
            ChangeState(value);
        }
    }
    void Awake()
    {
        current = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ChangeState(GameState.StartMenu);
    }

    void ChangeState(GameState name)
    {
        _currentState = name;
        GameEvents.current.GameStateChange();
    }
    
}

public enum GameState
{
    StartMenu,
    Game,
    GameOver
}
