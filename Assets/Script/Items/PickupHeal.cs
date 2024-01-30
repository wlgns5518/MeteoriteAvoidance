using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHeal : PickupItems
{
    private GravityAttractor attractor;

    protected override void OnPickedUp(GameObject receiver)
    {

    }


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

        }
        else
        {
            Destroy(gameObject, 5.0f);
        }
    }

}
