using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteo : GravityBody
{
    
    private bool IsCrashPlayer;

    protected override void Update()
    {
        base.Update();
        DestroyMetro();
    }

    private void DestroyMetro()
    {
        if(isGrounded == true)
        {
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)    //지면에 닿았을 시 발동하는 코드
    {
        // 바닥에 닿으면 isGrounded를 true로 설정
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            IsCrashPlayer = true;
        }
    }
}
