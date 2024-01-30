using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoAudio : MonoBehaviour
{
    public AudioClip drop;
    public AudioSource audioSource;
    // Start is called before the first frame update


    void OnCollisionEnter2D(Collision2D collision)    //플레이어에 닿았을 시 발동하는 코드
    {
        if (collision.gameObject.CompareTag("Meteor"))
        {
            audioSource.PlayOneShot(drop);
        }
    }



}
