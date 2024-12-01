using UnityEngine;

public class AgentRoomMover : MonoBehaviour
{
    public static AgentRoomMover Instance;

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

    public void MoveAgentToRoom(GameObject agent, Transform roomContainer)
    {
        if (agent == null || roomContainer == null)
        {
            GameLogger.LogWarning("Agent or Room container is null!");
            return;
        }

        // Reparent the agent to the room container
        agent.transform.SetParent(roomContainer, false);
        agent.SetActive(true); // Ensure the agent is visible in the room

        GameLogger.Log($"Moved Agent {agent.name} to Room {roomContainer.name}");
    }

    public void MoveAgentToPool(GameObject agent)
    {
        // Move the agent back to the agent pool
        AgentPoolManager.Instance.AddAgentToPool(agent);
    }
}
