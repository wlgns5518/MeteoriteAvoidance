using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    private GravityAttractor attractor;
    private bool isGrounded;

    private void Start()
    {
        attractor = FindObjectOfType<GravityAttractor>();
    }

    private void Update()
    {
        attractor.Attract(GetComponent<Rigidbody2D>());     //지구의 중력에 계속 이끌리도록 적용하는 코드



    }
    void OnCollisionEnter2D(Collision2D collision)    //지면에 닿았을 시 발동하는 코드
    {
        // 바닥에 닿으면 isGrounded를 true로 설정
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}