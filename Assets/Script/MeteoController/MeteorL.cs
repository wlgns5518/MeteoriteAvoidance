using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorL : MeteoController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        targetPoint = GameObject.FindGameObjectWithTag(targetTag).transform;

        transform.position = new Vector3(-x, y);
    }

   
}
