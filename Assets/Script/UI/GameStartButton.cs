using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;

public class GameStartButton : MonoBehaviour
{
    public AudioClip mouseCensor;
    public AudioClip mouseClick;
    public AudioSource audioSource;

    public void OnClick()
    {
        audioSource.PlayOneShot(mouseClick);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainScene");

    }

}
