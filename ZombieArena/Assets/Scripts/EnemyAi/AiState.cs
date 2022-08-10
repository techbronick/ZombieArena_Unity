﻿public enum AiStateId
{
    ChasePlayer,
    Death,
    Idle,
    Attack
}
public interface AiState
{
    AiStateId GetId();
    void Enter(AiAgent agent);
    void Update(AiAgent agent);
    void Exit(AiAgent agent);

}
