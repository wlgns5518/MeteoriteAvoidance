using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestartButton : MonoBehaviour
{
    public AudioClip mouseCensor;
    public AudioClip mouseClick;
    public AudioSource audioSource;
    public void Restart()
    {

        audioSource.PlayOneShot(mouseClick);

        SceneManager.LoadScene("MainScene");
    }
}
