using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameLobbyButton : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip mouseCensor;
    public AudioClip mouseClick;
    public AudioSource audioSource;

    public void MovetoLobby()
    {
        audioSource.PlayOneShot(mouseClick);
        SceneManager.LoadScene("LobbyScene");
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.PlayOneShot(mouseCensor);
    }
}
