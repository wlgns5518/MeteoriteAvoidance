using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupFakeGlove : PickupItems
{
    private GravityAttractor attractor;
    public string targetTag = "Meteor";

    protected override void OnPickedUp(GameObject receiver)
    {
        throw new System.NotImplementedException();
    }

    private void Start()
    {
        attractor = FindObjectOfType<GravityAttractor>();

    }

    private void Update()
    {
        attractor.Attract(GetComponent<Rigidbody2D>());
    }

    void DeleteObjectsWithTargetTag()
    {
        // ������ ��� GameObject�� ã�ƿɴϴ�.
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        // ã�� ��� GameObject�� ��ȸ�ϸ� �±װ� ��ġ�ϴ� ��� �����մϴ�.
        foreach (GameObject obj in allObjects)
        {
 
            if (obj.CompareTag(targetTag))
            {
                Destroy(obj);
            }
        }
    }


    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)    //�÷��̾ ����� �� �ߵ��ϴ� �ڵ�
    {
   
        if (collision.gameObject.CompareTag("Player"))
        {
            DeleteObjectsWithTargetTag();
            Destroy(gameObject);
        }

        else
        {
            Destroy(gameObject, 5.0f);
        }
    }
}
