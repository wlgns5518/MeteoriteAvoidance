using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_GravityBody : MonoBehaviour
{
    private GravityAttractor attractor;
    private bool isGrounded;
    private Rigidbody2D rb;
    public float jumpForce = 10f; // ���� �� ����
    public float jumpCooldown = 1f; // ��Ÿ�� ����
    public float orbitSpeed = 50f; // ���� �ӵ� ����
    private float lastJumpTime;

    private void Start()
    {
        attractor = FindObjectOfType<GravityAttractor>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            OrbitAroundAttractor(horizontalInput);
        }

        attractor.Attract(rb);

        // ����
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && Time.time - lastJumpTime > jumpCooldown)
        {
            Jump();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ���� �浹 ���
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void Jump()
    {
        //�� ������Ʈ�� ��ǥ ���
        Vector2 awayFromAttractor = ((Vector2)rb.position - (Vector2)attractor.transform.position).normalized;

        // �ݴ�������� ����
        rb.AddForce(awayFromAttractor * jumpForce, ForceMode2D.Impulse);

        // ���� ��Ÿ�� ���
        lastJumpTime = Time.time;

        // ������ ������ ����
        isGrounded = false;
    }

    void OrbitAroundAttractor(float horizontalInput)
    {
        float orbitDirection = Mathf.Sign(horizontalInput) * -1;
        transform.RotateAround(attractor.transform.position, Vector3.forward, orbitDirection * orbitSpeed * Time.deltaTime);
    }
}