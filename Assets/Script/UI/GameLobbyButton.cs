using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameLobbyButton : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    public AudioClip mouseCensor;
    public AudioClip mouseClick;
    public AudioSource audioSource;

    public void MovetoLobby()
    {
        SceneManager.LoadScene("LobbyScene");
   
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
