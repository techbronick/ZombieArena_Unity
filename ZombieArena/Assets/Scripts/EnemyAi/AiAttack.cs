using UnityEngine;

public class AiAttack : AiState
{
    public AiStateId GetId()
    {
        return AiStateId.Attack;
    }
    public void Enter(AiAgent agent)
    {

    }
    public void Update(AiAgent agent)
    {
        agent.animator.SetTrigger("attack");

        agent.navMeshAgent.SetDestination(agent.transform.position);

        if (!Physics.CheckSphere(agent.transform.position, agent.config.attackRange, agent.whatIsPlayer))
        {
            agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
        }



    }

    public void Exit(AiAgent agent)
    {

    }


}
