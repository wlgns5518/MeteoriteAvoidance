using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoAudio : MonoBehaviour
{
    public AudioClip drop;
    public AudioSource audioSource;
    // Start is called before the first frame update


    void OnCollisionEnter2D(Collision2D collision)    //�÷��̾ ����� �� �ߵ��ϴ� �ڵ�
    {
        if (collision.gameObject.CompareTag("Meteor"))
        {
            audioSource.PlayOneShot(drop);
        }
    }



}
