using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHeal : PickupItems
{
    private GravityAttractor attractor;

    //[SerializeField] int playerHp = 10;
    //private HealthSystem _healthSystem;

    protected override void OnPickedUp(GameObject receiver)
    {
        //_healthSystem = receiver.GetComponent<HealthSystem>();
        //_healthSystem.ChangeHealth(healValue);
    }

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

        }
        else
        {
            Destroy(gameObject, 5.0f);
        }
    }

}
