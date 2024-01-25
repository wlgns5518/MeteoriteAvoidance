using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    private GravityAttractor attractor;
    protected bool isGrounded;

    private void Start()
    {
        attractor = FindObjectOfType<GravityAttractor>();
    }

    protected virtual void Update()
    {
        attractor.Attract(GetComponent<Rigidbody2D>());     //������ �߷¿� ��� �̲������� �����ϴ� �ڵ�

    }
    void OnCollisionEnter2D(Collision2D collision)    //���鿡 ����� �� �ߵ��ϴ� �ڵ�
    {
        // �ٴڿ� ������ isGrounded�� true�� ����
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}