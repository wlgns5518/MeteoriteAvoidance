using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingButton : MonoBehaviour
{
    public AudioClip mouseCensor;
    public AudioClip mouseClick;
    public AudioSource audioSource;

    public GameObject gameSettingUI;
    public GameObject mainLobbyUI;
    public void GameSetting()
    {
        mainLobbyUI.SetActive(false);
        gameSettingUI.SetActive(true);
        audioSource.PlayOneShot(mouseClick);
    }

}
