using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTargeting : MonoBehaviour
{
    [SerializeField] private Transform payload;
    [SerializeField] private Transform player;

    private bool gotopayload = true;

    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (gotopayload == true)
        {
            navMeshAgent.destination = payload.position;
        }
        else if (gotopayload == false)
        {
            navMeshAgent.destination = player.position;
        }
    }

    IEnumerator waiter()
    {
        Debug.Log(gotopayload);
        yield return new WaitForSeconds(10);
        gotopayload = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gotopayload = false;
            StartCoroutine(waiter());
        }
    }
}
