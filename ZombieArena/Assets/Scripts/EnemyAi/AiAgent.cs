using UnityEngine;
using UnityEngine.AI;

public class AiAgent : MonoBehaviour
{
    public AiStateMachine stateMachine;
    public AiStateId initialState;
    public NavMeshAgent navMeshAgent;
    public AiAgentConfig config;
    public RagDoll ragDoll;
    public Animator animator;
    public LayerMask whatIsGround, whatIsPlayer;
    public Transform player;
    public GameObject RHand;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        stateMachine = new AiStateMachine(this);
        stateMachine.RegisterState(new AiChasePlayer());
        stateMachine.RegisterState(new AiDeath());
        stateMachine.RegisterState(new AiIdle());
        stateMachine.RegisterState(new AiAttack());
        stateMachine.ChangeState(initialState);
        RHand.GetComponent<Collider>().enabled = false;
    }


    void Update()
    {
        stateMachine.Update();
    }

    public void ActivateHand()
    {
        RHand.GetComponent<Collider>().enabled = true;
    }
    public void DeactivateHand()
    {
        RHand.GetComponent<Collider>().enabled = false;
    }
}
