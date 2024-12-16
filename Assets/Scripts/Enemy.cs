using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform goTo1;
    public Transform goTo2;
    public Transform goTo3;
    public Transform goTo4;
    int waitTimer = 0;
    int nextGoTo = 0;
    List<Transform> goToList;

    void Start()
    {
        goToList = new List<Transform>();
        waitTimer = Random.Range(300, 800);
        goTo1 = GameObject.Find("goTo1").transform;
        goTo2 = GameObject.Find("goTo2").transform;
        goTo3 = GameObject.Find("goTo3").transform;
        goTo4 = GameObject.Find("goTo4").transform;
        agent = GetComponent<NavMeshAgent>();
        goToList.Add(goTo1);
        goToList.Add(goTo2);
        goToList.Add(goTo3);
        goToList.Add(goTo4);
        agent.destination = goToList[Random.Range(0, 4)].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTimer > 0)
        {
            waitTimer--;
        }
        else
        {
            agent.destination = goToList[nextGoTo].position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("goTo"))
        {
            waitTimer = Random.Range(300, 800);
            int temp = Random.Range(0, 4);
            if (temp == nextGoTo)
            {
                Destroy(gameObject);
            }
            nextGoTo = temp;
        }
    }
}
