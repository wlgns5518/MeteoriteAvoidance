using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Player_GravityBody player_GravityBody;
    public Slider HpBar;
    public Slider StaminaBar;
    public void UpdateStats()
    {
        HpBar.value = player_GravityBody.playerHp / player_GravityBody.playerMaxhp;
        StaminaBar.value = player_GravityBody.stamina / player_GravityBody.maxStamina;
        if(player_GravityBody.playerHp <=0)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
