using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    private int spawntimer;

    void Start()
    {
        spawntimer = Random.Range(5000, 10000);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawntimer > 0)
        {
            spawntimer--;
        }
        else
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            spawntimer = Random.Range(5000, 10000);
        }
    }
}
