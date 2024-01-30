using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupstamina : PickupItems
{

    protected override void OnPickedUp(GameObject receiver)
    {
        throw new System.NotImplementedException();
    }

    private GravityAttractor attractor;

    public AudioClip pickup;
    public AudioSource audioSource;

    // Start is called before the first frame update
    private void Start()
    {
        attractor = FindObjectOfType<GravityAttractor>();
    }

    private void Update()
    {
        attractor.Attract(GetComponent<Rigidbody2D>());
    }


    void OnCollisionEnter2D(Collision2D collision)    //플레이어에 닿았을 시 발동하는 코드
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            audioSource.PlayOneShot(pickup);
        }
        else
        {
            Destroy(gameObject, 5.0f);
        }
    }


}
