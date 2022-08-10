using UnityEngine;

public class AiIdle : AiState
{
    private Vector3 walkPoint;
    bool walkPointSet;
    public AiStateId GetId()
    {
        return AiStateId.Idle;
    }
    public void Enter(AiAgent agent)
    {

    }
    public void Update(AiAgent agent)
    {
        agent.animator.SetFloat("speed", agent.navMeshAgent.speed);

        if (!walkPointSet) SearchWalkPoint(agent);

        if (walkPointSet)
            agent.navMeshAgent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = agent.transform.position - walkPoint;


        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

        if (Physics.CheckSphere(agent.transform.position, agent.config.sightRange, agent.whatIsPlayer))
        {
            agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
        }
    }

    public void Exit(AiAgent agent)
    {

    }

    private void SearchWalkPoint(AiAgent agent)
    {

        float randomZ = Random.Range(-agent.config.walkPointRange, agent.config.walkPointRange);
        float randomX = Random.Range(-agent.config.walkPointRange, agent.config.walkPointRange);

        walkPoint = new Vector3(agent.transform.position.x + randomX, agent.transform.position.y, agent.transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -agent.transform.up, 2f, agent.whatIsGround))
            walkPointSet = true;
    }
}
