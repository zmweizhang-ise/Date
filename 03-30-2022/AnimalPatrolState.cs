using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalPatrolState : AnimalBaseState
{

    private PatrolSpots patrol;
    private int randomSpot;
    private float speed = 10;

    public override void EnterState(AnimalStateManager animal)
    {
        Debug.Log("Is roaming");
        patrol = GameObject.FindGameObjectWithTag("PatrolSpots").GetComponent<PatrolSpots>();

    }

    public override void UpdateState(AnimalStateManager animal)
    {
        Vector3 patrolPointsPosition = new Vector3(patrol.patrolPoints[randomSpot].position.x, animal.transform.position.y, patrol.patrolPoints[randomSpot].position.z);

        //  Debug.Log(Vector3.Distance(animal.transform.position, patrol.patrolPoints[randomSpot].position));
        //Debug.Log(randomSpot);

        if (Vector3.Distance(animal.transform.position, patrolPointsPosition) > 0.2f)
        {
            animal.agent.SetDestination(patrol.patrolPoints[randomSpot].position);
        //    animal.transform.position = Vector3.MoveTowards(animal.transform.position, patrol.patrolPoints[randomSpot].position, speed * Time.deltaTime);
        }
        else
        {
            randomSpot = Random.Range(0, patrol.patrolPoints.Length);
        }
    }

    public override void OnCollisionEnter(AnimalStateManager animal, Collision collision)
    {

    }
}
