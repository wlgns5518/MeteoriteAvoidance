using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameSettingButton : MonoBehaviour, IPointerEnterHandler
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
    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.PlayOneShot(mouseCensor);
    }
}
