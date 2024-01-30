using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioLobbyManager : MonoBehaviour
{
    public AudioClip bgmusic;
    public AudioClip mouseClick;
    public AudioSource audioSource;
    public Object gameSettingUI;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = bgmusic;
        audioSource.Play();

        if(gameSettingUI == true)
        {
            //audioSource.PlayOneShot(mouseClick);
        }


    }

}
