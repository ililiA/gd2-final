using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int health = 30, xpValue = 50;

    public Transform[] points; // the array of patrol points
    public Transform player;

    private int destPoint = 0; // the current point to go
    private NavMeshAgent agent;

    private bool waiting = false;

    // Start is called before the first frame update
    void Start()
    {
        if(player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }
        Debug.Log("Starting Start");
        agent = this.GetComponent<NavMeshAgent>();

        // keep it form stopping at each patrol point
        // agent.autoBraking = false;

        StartCoroutine(GoToNextPoint());
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            health -= 10;
            if(health <= 0)
            {
                other.GetComponent<BulletController>().owner.ChangeXP(xpValue);
                Destroy (gameObject);
            }
        }
    }

    IEnumerator GoToNextPoint()
    {
        Debug.Log("Starting GoToNextPoint()");
        // if no points exist
        if(points.Length == 0)
        {
            yield return new WaitForEndOfFrame();;     //exit this method()
        }

        // wait for 2 seconds
        Debug.Log("Starting ToWait");
        waiting = true;
        agent.destination = this.transform.position;
        yield return new WaitForSeconds(2);
        waiting = false;
        
        // set the agent to go to the currently selected destination
        agent.destination = points[destPoint].position;

        //choose the next point in the array as the destination,
        // cyclying to the start if necessary
        destPoint = (destPoint + 1) % points.Length;
    }

    
    // Update is called once per frame
    void Update()
    {
        // when the ai gets close to a destination
        // go to the next point
        // ! is the NOT operator
        if(Vector3.Distance(this.transform.position, player.position) > 10)
        {
            Debug.Log("Not Following Player");
            if(!agent.pathPending && agent.remainingDistance < 0.5f && !waiting)
            {
              StartCoroutine(GoToNextPoint());
            }
        }
        else
        {
            Debug.Log("Following Player");
            agent.destination = player.position;
        }
    }
}
