using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int _health=100;

    private int _maxHealth = 20;

    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
    }

    public Text healthUi;

    [SerializeField]
    private PlayerColor color;
    public PlayerColor Color
    {
        get { return color;} 
    }
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = Mathf.Clamp(value, 0, 100);
            GameEvents.current.HealthChange();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthUi.text = _health.ToString();
        if (_health <= 0)
        {
            GameManager.current.CurrentState=GameState.GameOver;
            //Destroy(gameObject);
        }
    }
    public enum PlayerColor
    {
        Green,
        Red
    }
}
