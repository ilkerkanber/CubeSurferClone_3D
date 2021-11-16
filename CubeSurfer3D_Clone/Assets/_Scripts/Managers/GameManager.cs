using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : ASingleton<GameManager>
{
    public static event System.Action OnWinLevel;
    public static event System.Action OnLostLevel;
    [SerializeField] LevelCreater _levelCreater;
    public bool IsWin { get; set; }
    public bool IsLose { get; set; }
    public int CurrentLevel { get; set; }
    public int RoadLength { get; set; }
    
    void OnEnable()
    {
        LevelManager.OnNextLevel += ResetValues;
        LevelManager.OnRestartLevel += ResetValues;
    }
    void OnDisable()
    {
        LevelManager.OnNextLevel -= ResetValues;
        LevelManager.OnRestartLevel -= ResetValues;
    }
    void Awake()
    {
        CreateSingleton(this);

        RoadLength = 100;
        CurrentLevel = 1;
        _levelCreater.CreateLevel();
    }
    void Update()
    {
        if (IsLose)
        {
            OnLostLevel?.Invoke();
        }
        else if(IsWin)
        {
            OnWinLevel?.Invoke();
        }
    }
 
    void ResetValues()
    {
        Destroy(GameObject.FindGameObjectWithTag("LEVEL"));
        IsWin = false;
        IsLose = false;
    }
}