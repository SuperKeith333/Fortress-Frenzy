using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTargeting : MonoBehaviour
{
    [SerializeField] private Transform payload;
    [SerializeField] private Transform player;

    private bool gotopayload = true;

    public int enemyhealth = 100;

    private NavMeshAgent navMeshAgent;

    private bool TakeCover = false;

    private Vector3[] Cover = new Vector3[4];

    private Vector3[] SpawnLocations = new Vector3[4];

    public GameObject EminyPrefab;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        for(int i = 0; i < GameObject.FindGameObjectsWithTag("Cover").Length; i++)
        {
            Cover[i] = GameObject.FindGameObjectsWithTag("Cover")[i].transform.position;
        }
        for(int i = 0; i < GameObject.FindGameObjectsWithTag("Enimy Spawn").Length; i++)
        {
            SpawnLocations[i] = GameObject.FindGameObjectsWithTag("Enimy Spawm")[i].transform.position;
        }
    }
    
    private void SpawnEnemys()
    {
        // called when enimy is at certain health (now implemeted)
        GameObject newEnimy = Instantiate(EminyPrefab);
        newEnimy.transform.position = SpawnLocations[Random.Range(0, SpawnLocations.Length)];
    }

    private void Update()
    {
        if (enemyhealth <= 0)
        {
            SpawnEnemys();
            Destroy(this.gameObject);
        }

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
    IEnumerator waiter2()
    {
        yield return new WaitForSeconds(20);
        if(Random.Range(0, 5) == 0 || Random.Range(0, 5) == 1)
        {
            navMeshAgent.destination = Cover[Random.Range(0, 5)];
        }
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
