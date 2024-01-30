using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoController : MonoBehaviour
{
    protected Transform targetPoint;
    [SerializeField] private ParticleSystem _particle;

    protected float x;
    protected float y;
    private float speed;
    protected bool IsCrash = false;
    [SerializeField] protected string targetTag;
    [SerializeField] protected Animator anim;


    protected virtual void Start()   // 운석의 스피드와 생성될 위치를 
    {
        speed = Random.Range(3, 6);
        x = Random.Range(8, 10);
        y = Random.Range(-8, 8);    
    }

    private void Update()
    {
        meteorMove();
        DestroyMeteor();
    }

    private void meteorMove()  // 운석이 타겟 방향으로 가도록 설정
    {
        if (targetPoint == null)
            return;
        Vector3 direction = targetPoint.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    private void DestroyMeteor()
    {
        if (IsCrash)
        {
            anim.SetBool("IsCrash", true);
            Destroy(gameObject, 0.06f);
        }
    }

     void OnCollisionEnter2D(Collision2D collision)    //지면에 닿았을 시 발동하는 코드
    {
        // 바닥이나 플레이어에 닿으면 오브젝트 삭제
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsCrash = true;
            
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            IsCrash = true;
        }
    }


}
