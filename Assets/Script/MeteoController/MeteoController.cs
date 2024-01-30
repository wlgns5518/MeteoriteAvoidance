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


    protected virtual void Start()   // ��� ���ǵ�� ������ ��ġ�� 
    {
        speed = Random.Range(3, 6);
        x = Random.Range(8, 10);
        y = Random.Range(-8, 8);    
    }

    private void Update()
    {
        meteorMove();        
    }

    private void meteorMove()  // ��� Ÿ�� �������� ������ ����
    {
        if (targetPoint == null)
            return;
        Vector3 direction = targetPoint.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }


     void OnCollisionEnter2D(Collision2D collision)    //���鿡 ����� �� �ߵ��ϴ� �ڵ�
    {
        // �ٴ��̳� �÷��̾ ������ ������Ʈ ����
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
