using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSetting : MonoBehaviour
{
    GameManager gameManager;
    public static float time;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        time = gameManager.time;
    }
}
