using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorR : MeteoController
{
 
    protected override void Start()  // ȭ�� �����ʿ��� ���� x��ǥ(8 ~ 10), y��ǥ(-8 ~ 8)
    {
        base.Start();
        targetPoint = GameObject.FindGameObjectWithTag(targetTag).transform;

        transform.position = new Vector3(x, y);
    }
}
