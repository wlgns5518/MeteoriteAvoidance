using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    static GameManager gameManager;
    public TextMeshProUGUI setTimeUI;
    public TextMeshProUGUI bestTimeUI;
    public float time;
    public float bestTime;

    private void Start()
    {
        gameManager = GameManager.Instance;
        if (gameManager != null)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        time = gameManager.time;
        setTimeUI.text = "Time : " +time.ToString("N2");
        if(bestTime < time) 
        { 
            bestTime = time;
        }
        bestTimeUI.text = "BestTime : "+bestTime.ToString("N2");
    }
}
