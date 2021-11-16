using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : ASingleton<LevelManager>
{
    public static event System.Action OnNextLevel;
    public static event System.Action OnRestartLevel;

    void Awake()
    {
        CreateSingleton(this);
    }
    public void NextLevel()
    {
        if(GameManager.Instance.CurrentLevel != 5)
        {
            GameManager.Instance.CurrentLevel++;
            GameManager.Instance.RoadLength += 50;
        }
        OnNextLevel?.Invoke();
    }
    public void RestartLevel()
    {
        OnRestartLevel?.Invoke();
    }
}
