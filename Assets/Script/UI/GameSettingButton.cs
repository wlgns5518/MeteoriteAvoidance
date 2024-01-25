using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingButton : MonoBehaviour
{
    public GameObject gameSettingUI;
    public GameObject mainLobbyUI;
    public void GameSetting()
    {
        mainLobbyUI.SetActive(false);
        gameSettingUI.SetActive(true);
    }
}
