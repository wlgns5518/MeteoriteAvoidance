using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoController : MonoBehaviour
{
    protected Transform targetPoint;

    protected float x;
    protected float y;
    private float speed;
    [SerializeField] protected string targetTag;

    protected virtual void Start()
    {
        speed = Random.Range(3, 6);
        x = Random.Range(8, 10);
        y = Random.Range(-8, 8);    
    }

    private void Update()
    {
        meteorMove();        
    }

    private void meteorMove()
    {
        if (targetPoint == null)
            return;
        Vector3 direction = targetPoint.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }


     void OnCollisionEnter2D(Collision2D collision)    //지면에 닿았을 시 발동하는 코드
    {
        // 바닥에 닿으면 isGrounded를 true로 설정
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
