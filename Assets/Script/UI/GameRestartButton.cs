using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestartButton : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }
}
