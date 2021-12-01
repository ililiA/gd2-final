using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follower : MonoBehaviour
{
    public Animator anim;
    public Transform player;

    private NavMeshAgent agent;

    private bool waiting = false;

    void Awake()
    {
        if(player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting Start");
        agent = this.GetComponent<NavMeshAgent>();

        if(player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }

        // keep it form stopping at each patrol point
        // agent.autoBraking = false;
    }

/*
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
    */

    
    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", agent.velocity.magnitude);
        // when the ai gets close to a destination
        // go to the next point
        // ! is the NOT operator
        if(Vector3.Distance(this.transform.position, player.position) > 2)
        {
            Debug.Log("Not Following Player");
            if(!agent.pathPending && agent.remainingDistance < 0.5f && !waiting)
            {
              agent.destination = player.position;
            }
        }
        else
        {
            Debug.Log("Following Player");
            agent.destination = this.transform.position;
        }
    }

}
