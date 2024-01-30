using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLobbyButton : MonoBehaviour
{
    public AudioClip mouseCensor;
    public AudioClip mouseClick;
    public AudioSource audioSource;

    public void MovetoLobby()
    {
        audioSource.PlayOneShot(mouseClick);
        SceneManager.LoadScene("LobbyScene");
    }
}
