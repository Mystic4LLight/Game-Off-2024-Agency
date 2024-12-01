using UnityEngine;
using System.Collections.Generic;

public class AgentPoolManager : MonoBehaviour
{
    public static AgentPoolManager Instance;

    [SerializeField] private List<GameObject> agentPool = new List<GameObject>(); // Pool to store instantiated agent prefabs

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddAgentToPool(GameObject agent)
    {
        agentPool.Add(agent);
        agent.transform.SetParent(this.transform, false); // Reparent to the pool
        
    agent.SetActive(false); // Hide agents in the pool by default
    GameLogger.Log($"Agent {agent.name} added to the pool.");
    
    }

    public void RemoveAgentFromPool(GameObject agent)
    {
        if (agentPool.Contains(agent))
        {
            agentPool.Remove(agent);
            
    agent.SetActive(true); // Reactivate the agent when it's removed from the pool
    GameLogger.Log($"Agent {agent.name} removed from the pool.");
    
        }
    }

    public GameObject GetAgentFromPool(AgentSO agentSO)
    {
        // Find the agent in the pool by matching the AgentSO
        foreach (GameObject agent in agentPool)
        {
            var agentUI = agent.GetComponent<AgentUI>();
            if (agentUI != null && agentUI.agentSO == agentSO)
            {
                return agent;
            }
        }
        return null;
    }
}
