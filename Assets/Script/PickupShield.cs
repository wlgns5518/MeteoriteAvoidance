using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PickupShield : PickupItems
{
    protected override void OnPickedUp(GameObject receiver)
    {
        gameObject.SetActive(true);
    }




}
