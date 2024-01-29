using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    private GravityAttractor attractor; //지구 오브젝트 참조용


    // Start is called before the first frame update
    private void Start()
    {
        attractor = FindObjectOfType<GravityAttractor>();
    }

    // Update is called once per frame
    private void Update()
    {
        float orbitDirection = Mathf.Sign(1);
        transform.RotateAround(attractor.transform.position, Vector3.forward, orbitDirection * 250 * Time.deltaTime);
    }
}
