using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameExitButton : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip mouseCensor;
    public AudioClip mouseClick;
    public AudioSource audioSource;
    public void ExitGame()
    {
        audioSource.PlayOneShot(mouseClick);
        Application.Quit();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.PlayOneShot(mouseCensor);
    }
}
