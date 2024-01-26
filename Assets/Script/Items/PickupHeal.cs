using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHeal : PickupItems
{
    [SerializeField] int playerHp = 10;
    //private HealthSystem _healthSystem;

    protected override void OnPickedUp(GameObject receiver)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update

}
