using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLobbyButton : MonoBehaviour
{
    public void MovetoLobby()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}
