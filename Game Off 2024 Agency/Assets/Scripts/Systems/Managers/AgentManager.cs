using UnityEngine;

public class AgentManager : MonoBehaviour
{
    public Transform agentPoolManager;

    public void MoveAgentToPool(GameObject agent)
    {
        if (agent == null)
        {
            
    if (agent == null)
    {
        GameLogger.LogError("MoveAgentToPool: Attempted to move a null agent to the pool.");
        return;
    }
    if (agentPoolManager == null)
    {
        GameLogger.LogError("AgentPoolManager reference is missing. Cannot move agent to the pool.");
        return;
    }
    
            return;
        }

        GameLogger.Log($"Attempting to move agent: {agent.name}, active: {agent.activeSelf}, in scene: {agent.scene.name}");

        if (!agent.activeSelf)
        {
            agent.SetActive(true); // Ensure agent is active
        }

        agent.transform.SetParent(agentPoolManager); // Move to pool container
        GameLogger.Log($"Agent {agent.name} successfully moved to the pool.");
    }
}
