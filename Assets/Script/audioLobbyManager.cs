using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioLobbyManager : MonoBehaviour
{
    public AudioClip bgmusic;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = bgmusic;
        audioSource.Play();
    }

}
