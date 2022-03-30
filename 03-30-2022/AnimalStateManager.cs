using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalStateManager : MonoBehaviour
{

    AnimalBaseState currentState;
    public AnimalPatrolState PatrolState = new AnimalPatrolState();
    public AnimalChaseState ChaseState = new AnimalChaseState();
    public NavMeshAgent agent;


    void Start()
    {
        currentState = PatrolState;
        currentState.EnterState(this);
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(AnimalBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }
}
