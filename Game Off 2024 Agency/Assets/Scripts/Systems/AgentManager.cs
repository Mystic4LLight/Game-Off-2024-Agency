using UnityEngine;
using System.Collections.Generic;

public class AgentManager : MonoBehaviour
{
    public List<Agent> agents = new List<Agent>();
    [SerializeField] Agent agentPrefab;
    [SerializeField] public List<AgentSO> agentsSO = new List<AgentSO>();
    [SerializeField] public Transform agentSpawnPoint;
    public List<Agent> activeAgents = new List<Agent>();    
    public static AgentManager Instance;
    public RecruitmentPanel recruitmentPanel; // Reference to the RecruitmentPanel

    public Transform agentPoolManager; // Reference to manage agents in the pool

    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void RecruitAgent(AgentSO agentSO)
    {        
        Agent newAgent = Instantiate(agentPrefab, agentSpawnPoint.transform.position, agentPrefab.transform.rotation);
        newAgent.agentSO = agentSO;
        activeAgents.Add(newAgent);
        // Remove from recruitment pool
        RemoveFromRecruitmentPool(agentSO);

        // Optional: Call a UI update function here if needed
    }

    public void RemoveFromRecruitmentPool(AgentSO agentSO)
    {
        agentsSO.Remove(agentSO); // Remove from available agents
        GameLogger.Log($"Removed {agentSO.agentName} from the recruitment pool.");
    }

    public void RejectAgent(AgentSO agentSO)
    {
        RemoveFromRecruitmentPool(agentSO);
        GameLogger.Log($"Rejected Agent: {agentSO.agentName}");
        recruitmentPanel.RefreshPanel();
    }

    public Agent SelectAgent(Agent agent)
    {
        return agent;
    }

    // New function from branch version to move agent to pool
    public void MoveAgentToPool(GameObject agent)
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

        GameLogger.Log($"Attempting to move agent: {agent.name}, active: {agent.activeSelf}, in scene: {agent.scene.name}");

        if (!agent.activeSelf)
        {
            agent.SetActive(true); // Ensure agent is active
        }

        agent.transform.SetParent(agentPoolManager); // Move to pool container
        GameLogger.Log($"Agent {agent.name} successfully moved to the pool.");
    }
}
