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

    void OnCollisionEnter2D(Collision2D collision)    //���鿡 ����� �� �ߵ��ϴ� �ڵ�
    {
        // �ٴڿ� ������ isGrounded�� true�� ����
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
