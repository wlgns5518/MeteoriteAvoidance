using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenStaminaitem : MonoBehaviour
{

    private GravityAttractor attractor;
    // Start is called before the first frame update
    private void Start()
    {
        attractor = FindObjectOfType<GravityAttractor>();
    }
    private void Update()
    {
        attractor.Attract(GetComponent<Rigidbody2D>());
    }

    void OnCollisionEnter2D(Collision2D collision)    //�÷��̾ ����� �� �ߵ��ϴ� �ڵ�
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);

        }
        else
        {
            Destroy(gameObject, 5.0f);
        }
    }
}
