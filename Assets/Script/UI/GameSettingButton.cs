using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameSettingButton : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    public GameObject gameSettingUI;
    public GameObject mainLobbyUI;
    public AudioClip mouseCensor;
    public AudioClip mouseClick;
    public AudioSource audioSource;

    public void GameSetting()
    {

        mainLobbyUI.SetActive(false);
        gameSettingUI.SetActive(true);

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.PlayOneShot(mouseCensor);
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        audioSource.PlayOneShot(mouseClick);
    }
}
