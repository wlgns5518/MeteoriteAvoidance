using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;
using UnityEngine.EventSystems;

public class GameStartButton : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip mouseCensor;
    public AudioClip mouseClick;
    public AudioSource audioSource;

    public void OnClick()
    {

        audioSource.PlayOneShot(mouseClick);

        SceneManager.LoadScene("MainScene");

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.PlayOneShot(mouseCensor);
    }
}
