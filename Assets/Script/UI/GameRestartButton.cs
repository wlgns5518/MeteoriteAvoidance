using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameRestartButton : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip mouseCensor;
    public AudioClip mouseClick;
    public AudioSource audioSource;
    public void Restart()
    {

        audioSource.PlayOneShot(mouseClick);

        SceneManager.LoadScene("MainScene");
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.PlayOneShot(mouseCensor);
    }
}
