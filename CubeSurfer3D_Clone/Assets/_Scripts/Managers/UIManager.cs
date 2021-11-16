using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : ASingleton<UIManager>
{
    [SerializeField] GameObject WinCanvas;
    [SerializeField] GameObject LoseCanvas;
    [SerializeField] Text scoreText;

    void OnEnable()
    {
        GameManager.OnWinLevel += EnableWinCanvas;
        GameManager.OnLostLevel += EnableLoseCanvas;
    }
    void OnDisable()
    {
        GameManager.OnWinLevel -= EnableWinCanvas;
        GameManager.OnLostLevel -= EnableLoseCanvas;
    }
    void Awake()
    {
        CreateSingleton(this);   
    }
    public void EnableWinCanvas()
    {
        scoreText.text = FindObjectOfType<PlayerController>().transform.GetChild(0).childCount.ToString();
        WinCanvas.SetActive(true);
    }
    public void EnableLoseCanvas()
    {
        LoseCanvas.SetActive(true);
    }
}
