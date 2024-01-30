using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI setTimeUI;
    public TextMeshProUGUI bestTimeUI;
    public float time;
    public float bestTime;

    private void Start()
    {
        GameOver();
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        time = GameManager.time;
        setTimeUI.text = time.ToString("N2");
        bestTime = PlayerPrefs.GetFloat("BestTime");
        if(bestTime < time) 
        { 
            bestTime = time;
            PlayerPrefs.SetFloat("BestTime",bestTime);
}
        bestTimeUI.text = bestTime.ToString("N2");
    }
}
