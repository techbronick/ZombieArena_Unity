public class AiDeath : AiState
{
    public AiStateId GetId()
    {
        return AiStateId.Death;
    }
    public void Enter(AiAgent agent)
    {
    }
    public void Update(AiAgent agent)
    {
        agent.navMeshAgent.enabled = false;
        agent.enabled = false;
        agent.animator.SetTrigger("death");

    }

    public void Exit(AiAgent agent)
    {

    }




}
