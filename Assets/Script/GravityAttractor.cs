using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    public float gravity = -20f; // �߷� ���
    public float friction = 5f; // ���� ���
    public float rotationSpeed = 10f; //ȸ�� �ӵ�
    public int rotationDirection = 1; //ȸ�� ����

    public void Start()
    {
        InvokeRepeating("RotateSpeedUp", 0f, 0.1f);
        InvokeRepeating("RotateDirectionChange", 0f, 6f);
    }


    // �߷� ���� �Լ�
    public void Attract(Rigidbody2D body)
    {
        Vector2 gravityUp = (body.position - (Vector2)transform.position).normalized;
        Vector2 localUp = body.transform.up;

        // �߷� �������� ȸ��
        body.AddForce(gravityUp * gravity);

        // ��ü�� ������ �߷� �������� ����
        body.rotation = Mathf.Lerp(body.rotation, Mathf.Atan2(localUp.y, localUp.x) * Mathf.Rad2Deg, 5f * Time.deltaTime);

        // ���� ����
        Vector2 frictionForce = -body.velocity.normalized * friction;
        body.AddForce(frictionForce);
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime * rotationDirection); //ȸ��
    }

    public void RotateSpeedUp()
    {
        rotationSpeed += 0.12f;
    }
    public void RotateDirectionChange()
    {
        if(rotationDirection == 1)
        {
            rotationDirection = -1;
        }
        else
        {
            rotationDirection = 1;
        }
    }
}
