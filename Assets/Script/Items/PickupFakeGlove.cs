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
        // 씬에서 모든 GameObject를 찾아옵니다.
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        // 찾은 모든 GameObject를 순회하며 태그가 일치하는 경우 삭제합니다.
        foreach (GameObject obj in allObjects)
        {
 
            if (obj.CompareTag(targetTag))
            {
                Destroy(obj);
            }
        }
    }


    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)    //플레이어에 닿았을 시 발동하는 코드
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
