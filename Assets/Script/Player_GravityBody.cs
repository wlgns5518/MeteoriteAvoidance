using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_GravityBody : MonoBehaviour
{
    private GravityAttractor attractor;
    private bool isGrounded;
    private Rigidbody2D rb;
    public float jumpForce = 10f; // 점프 힘 조절
    public float jumpCooldown = 1f; // 쿨타임 조절
    public float orbitSpeed = 50f; // 공전 속도 조절
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

        // 점프
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && Time.time - lastJumpTime > jumpCooldown)
        {
            Jump();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 땅과 충돌 계산
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void Jump()
    {
        //두 오브젝트의 좌표 계산
        Vector2 awayFromAttractor = ((Vector2)rb.position - (Vector2)attractor.transform.position).normalized;

        // 반대방향으로 점프
        rb.AddForce(awayFromAttractor * jumpForce, ForceMode2D.Impulse);

        // 점프 쿨타임 계산
        lastJumpTime = Time.time;

        // 땅에서 떨어짐 판정
        isGrounded = false;
    }

    void OrbitAroundAttractor(float horizontalInput)
    {
        float orbitDirection = Mathf.Sign(horizontalInput) * -1;
        transform.RotateAround(attractor.transform.position, Vector3.forward, orbitDirection * orbitSpeed * Time.deltaTime);
    }
}