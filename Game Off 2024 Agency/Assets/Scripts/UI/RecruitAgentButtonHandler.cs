using UnityEngine;

public class RecruitAgentButtonHandler : MonoBehaviour
{
    public GameObject agentGameObject; // Assigned through the manager
    public Transform agentPool; // Assign this in the Inspector or dynamically

    public void OnRecruitButtonClicked()
    {
        if (agentGameObject == null)
        {
            GameLogger.LogError("OnRecruitButtonClicked: agentGameObject is null. Cannot proceed with recruitment.");
            return;
        }

        if (agentPool == null)
        {
            GameLogger.LogError("OnRecruitButtonClicked: agentPool reference is null. Cannot recruit agent.");
            return;
        }

        // Move the agent GameObject to the agent pool
        agentGameObject.transform.SetParent(agentPool, false);
        GameLogger.Log($"Recruited agent: {agentGameObject.name} and moved to agentPool.");
    }

    public void SetAgent(GameObject agent)
    {
        agentGameObject = agent;
        GameLogger.Log($"RecruitAgentButtonHandler: Assigned agentGameObject for agent: {agent.name}");
    }
}
