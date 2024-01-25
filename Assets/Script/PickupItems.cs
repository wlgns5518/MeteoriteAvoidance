using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Connect;
using UnityEngine;

public abstract class PickupItems : MonoBehaviour
{
    [SerializeField] private bool destroyOnPickup = true;
    [SerializeField] private LayerMask canBePickupBy;
    [SerializeField] private AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(canBePickupBy.value == (canBePickupBy.value | (1 << other.gameObject.layer)))
        {
            OnPickedUp(other.gameObject);
            //if (pickupSound)
            //    SoundManager.PlayClip(pickupSound);

            if (destroyOnPickup)
            {

            }
        }
    }

    protected abstract void OnPickedUp(GameObject receiver);

}

