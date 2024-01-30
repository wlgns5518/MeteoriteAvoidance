using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExitButton : MonoBehaviour
{
    public AudioClip mouseCensor;
    public AudioClip mouseClick;
    public AudioSource audioSource;
    public void ExitGame()
    {
        audioSource.PlayOneShot(mouseClick);
        Application.Quit();
    }


}
