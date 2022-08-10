using UnityEngine;
public class AiChasePlayer : AiState
{
    public AiStateId GetId()
    {
        return AiStateId.ChasePlayer;
    }

    public void Enter(AiAgent agent)
    {

    }

    public void Update(AiAgent agent)
    {
        agent.animator.SetFloat("speed", agent.navMeshAgent.speed);

        agent.navMeshAgent.SetDestination(agent.player.position);

        if (Physics.CheckSphere(agent.transform.position, agent.config.attackRange, agent.whatIsPlayer))
        {
            agent.stateMachine.ChangeState(AiStateId.Attack);
        }
        else
        {
            agent.stateMachine.ChangeState(AiStateId.Idle);
        }
    }


    public void Exit(AiAgent agent)
    {

    }




}
