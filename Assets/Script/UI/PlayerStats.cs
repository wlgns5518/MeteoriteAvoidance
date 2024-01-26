using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Slider HpBar;
    public Slider StaminaBar;
    public void UpdateStats()
    {
        Player_GravityBody player_GravityBody = new Player_GravityBody();
        GameOverUI gameOverUI = new GameOverUI();
        HpBar.value = player_GravityBody.playerHp / player_GravityBody.playerMaxhp;
        StaminaBar.value = player_GravityBody.stamina / player_GravityBody.maxStamina;
        if(player_GravityBody.playerHp <=0)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
