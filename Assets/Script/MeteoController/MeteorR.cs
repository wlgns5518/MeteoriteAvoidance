using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorR : MeteoController
{


    protected override void Start()
    {
        base.Start();
        targetPoint = GameObject.FindGameObjectWithTag(targetTag).transform;

        transform.position = new Vector3(x, y);
    }

}
