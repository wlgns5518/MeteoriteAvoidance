using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorL : MeteoController
{
    
    protected override void Start()  // È­¸é ¿ŞÂÊ¿¡ ¿î¼®ÀÌ »ı¼ºµÊ xÁÂÇ¥ (-8 ~ -10), yÁÂÇ¥ (-8 ~ 8) 
    {
        base.Start();
        targetPoint = GameObject.FindGameObjectWithTag(targetTag).transform;

        transform.position = new Vector3(-x, y);
    }
}
