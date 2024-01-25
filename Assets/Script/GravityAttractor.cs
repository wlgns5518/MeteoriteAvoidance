using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    public float gravity = -20f; // 중력 상수
    public float friction = 5f; // 마찰 상수
    public float rotationSpeed = 10f; //회전 속도


    // 중력 적용 함수
    public void Attract(Rigidbody2D body)
    {
        Vector2 gravityUp = (body.position - (Vector2)transform.position).normalized;
        Vector2 localUp = body.transform.up;

        // 중력 방향으로 회전
        body.AddForce(gravityUp * gravity);

        // 물체의 방향을 중력 방향으로 맞춤
        body.rotation = Mathf.Lerp(body.rotation, Mathf.Atan2(localUp.y, localUp.x) * Mathf.Rad2Deg, 5f * Time.deltaTime);

        // 마찰 적용
        Vector2 frictionForce = -body.velocity.normalized * friction;
        body.AddForce(frictionForce);
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime); //회전
    }
}
