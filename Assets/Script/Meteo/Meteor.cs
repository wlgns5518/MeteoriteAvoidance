using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private Transform targetPoint;
    private bool IsGrounded;
    private bool IsCrashPlayer;

    [SerializeField] private float speed = 5f;
    [SerializeField] private string targetTag = "Ground";

    private void Start()
    {
        targetPoint = GameObject.FindGameObjectWithTag(targetTag).transform;
    }

    private void Update()
    {
        meteorMove();
        DestroyMetro();
    }

    private void meteorMove()
    {
        if (targetPoint == null)
            return;
        Vector3 direction = targetPoint.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    private void DestroyMetro()
    {
        if(IsGrounded == true)
        {
            Destroy(gameObject);
        }
    }

     void OnCollisionEnter2D(Collision2D collision)    //지면에 닿았을 시 발동하는 코드
    {
        // 바닥에 닿으면 isGrounded를 true로 설정
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            IsCrashPlayer = true;
        }
    }
}
