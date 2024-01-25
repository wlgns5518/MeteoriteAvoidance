using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueshielditem : MonoBehaviour
{

    private GravityAttractor attractor;
    // Start is called before the first frame update
    void Start()
    {
        attractor = FindObjectOfType<GravityAttractor>();
    }

    // Update is called once per frame
    void Update()
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

        if (collision.gameObject.CompareTag("shield"))
        {
            //activeshield();
        }
    }

}
