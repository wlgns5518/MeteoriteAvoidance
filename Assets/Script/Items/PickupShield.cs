using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PickupShield : PickupItems
{

    protected override void OnPickedUp(GameObject receiver)
    {
        throw new System.NotImplementedException();
    }

    public AudioClip pickup;
    public AudioSource audioSource;


    private GravityAttractor attractor;
    // Start is called before the first frame update
    private void Start()
    {
        attractor = FindObjectOfType<GravityAttractor>();
    }

    private void Update()
    {
        attractor.Attract(GetComponent<Rigidbody2D>());
    }



    void OnCollisionEnter2D(Collision2D collision)    //�÷��̾ ����� �� �ߵ��ϴ� �ڵ�
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
