using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorD : MeteoController
{
  
    protected override void Start()  // 화면 아래쪽 에서 생성 x좌표(-8 ~ 8), y좌표(-8 ~ -10)
    {
        base.Start();
        targetPoint = GameObject.FindGameObjectWithTag(targetTag).transform;

        transform.position = new Vector3(y, -x);
    }
}
