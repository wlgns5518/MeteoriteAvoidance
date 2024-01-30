using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorR : MeteoController
{
 
    protected override void Start()  // 화면 오른쪽에서 생성 x좌표(8 ~ 10), y좌표(-8 ~ 8)
    {
        base.Start();
        targetPoint = GameObject.FindGameObjectWithTag(targetTag).transform;

        transform.position = new Vector3(x, y);
    }
}
