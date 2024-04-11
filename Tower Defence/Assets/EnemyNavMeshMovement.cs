using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshMovement : MonoBehaviour
{
    private Enemy enemy;
    public GameObject destination;
    public NavMeshAgent agnet;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        agnet = GetComponent<NavMeshAgent>();
        
        agnet.SetDestination(GameObject.Find("End").transform.position);
    }

    // Update is called once per frame
    void Update()
    {
	    agnet.speed = enemy.speed;
	    if (agnet.remainingDistance <= agnet.stoppingDistance+.5f)
	    {
		    EndPath();
	    }
    }
    
    void EndPath()
    	{
    		PlayerStats.Lives--;
    		WaveSpawner.EnemiesAlive--;
    		Destroy(gameObject);
    	}
}
