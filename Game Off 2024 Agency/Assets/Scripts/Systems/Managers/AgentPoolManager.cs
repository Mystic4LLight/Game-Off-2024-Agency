using UnityEngine;
using System.Collections.Generic;

public class AgentPoolManager : MonoBehaviour
{
    public static AgentPoolManager Instance;

    [SerializeField] private Transform availableAgentPoolTransform; // Reference to the Available Agent Pool UI Transform
    [SerializeField] private Transform medBayContainer; // Reference to the Med Bay container
    [SerializeField] private Transform trainingRoomContainer; // Reference to the Training Room container
    [SerializeField] private Transform dormitoriesContainer; // Reference to the Dormitories container
    [SerializeField] private List<GameObject> agentPool = new List<GameObject>(); // Pool to store instantiated agent prefabs

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Method to move an agent to a specific room container
    public void MoveAgentToRoom(GameObject agent, Transform roomTransform)
    {
        if (agent == null || roomTransform == null)
        {
            GameLogger.LogError("MoveAgentToRoom: Agent or roomTransform is null. Cannot move agent.");
            return;
        }

        agent.transform.SetParent(roomTransform, false);
        GameLogger.Log($"Agent {agent.name} moved to {roomTransform.name}");
    }

    // Method to move an agent to the available agent pool
    public void MoveAgentToAvailablePool(GameObject agent)
    {
        if (agent == null)
        {
            GameLogger.LogError("MoveAgentToAvailablePool: Agent is null. Cannot move agent.");
            return;
        }

        agent.transform.SetParent(availableAgentPoolTransform, false);
        GameLogger.Log($"Agent {agent.name} moved back to the Available Agent Pool.");
    }

    // Method to get room container by room name
    public Transform GetRoomContainer(string roomName)
    {
        switch (roomName)
        {
            case "MedBay":
                return medBayContainer;
            case "TrainingRoom":
                return trainingRoomContainer;
            case "Dormitories":
                return dormitoriesContainer;
            default:
                GameLogger.LogError($"GetRoomContainer: No container found for room name '{roomName}'");
                return null;
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
