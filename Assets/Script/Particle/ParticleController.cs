using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] private ParticleSystem boomparticle;
    [SerializeField] private ParticleSystem healparticle;

    public void CreateHealParticle(Vector3 position)
    {
        healparticle.transform.position = position;
        healparticle.Play();
    }

    public void Createboomparticle(Vector3 position)
    {
        boomparticle.transform.position = position;
        boomparticle.Play();
    }
}
