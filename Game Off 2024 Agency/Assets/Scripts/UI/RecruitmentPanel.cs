using System.Collections;
using UnityEngine;

public class RecruitmentPanel : MonoBehaviour
{
    public Transform recruitmentGrid; // Parent for the recruitment slots
    public GameObject agentUIPrefab;  // Prefab for agent cards
    public AgentGenerator agentGenerator; // Reference to the AgentGenerator
    [SerializeField] public GameObject[] recruitmentSlots; // Empty game objects as placeholders

    private void Start()
    {
        if (!ValidateReferences())
        {
            Debug.LogError("RecruitmentPanel: Missing critical references. Initialization aborted.");
            return;
        }

        StartCoroutine(InitializeRecruitmentPanel());
    }

    private bool ValidateReferences()
    {
        if (recruitmentGrid == null || agentUIPrefab == null || agentGenerator == null || recruitmentSlots == null || recruitmentSlots.Length == 0)
        {
            Debug.LogWarning("RecruitmentPanel: Missing references in the Inspector.");
            return false;
        }

        return true;
    }

    private IEnumerator InitializeRecruitmentPanel()
    {
        yield return new WaitForEndOfFrame(); // Allow other scripts to finish initialization

        for (int i = 0; i < recruitmentSlots.Length; i++)
        {
            if (recruitmentSlots[i] == null)
            {
                Debug.LogError($"RecruitmentPanel: Slot {i} is null. Ensure all slots are assigned.");
                continue;
            }

            // Generate an agent
            string archetype = AgentTemplateManager.GetRandomArchetype();
            string occupation = AgentTemplateManager.GetRandomOccupation(archetype);
            GameObject agentObject = agentGenerator.GenerateAgent(archetype, occupation);

            if (agentObject != null)
            {
                // Activate the instantiated agent card
                agentObject.SetActive(true);

                // Replace the empty slot with the agent card
                Destroy(recruitmentSlots[i]); // Remove the placeholder
                agentObject.transform.SetParent(recruitmentGrid, false);
                agentObject.transform.SetSiblingIndex(i); // Match the original slot index in the layout

                // Initialize the AgentUI component
                AgentUI agentUI = agentObject.GetComponent<AgentUI>();
                if (agentUI != null)
                {
                    Debug.Log($"RecruitmentPanel: Agent card successfully added to slot {i}.");
                }
                else
                {
                    Debug.LogError($"RecruitmentPanel: AgentUI missing on instantiated prefab at slot {i}.");
                }
            }
            else
            {
                Debug.LogError($"RecruitmentPanel: Failed to generate agent for slot {i}.");
            }
        }

        Debug.Log("RecruitmentPanel: Initialization complete.");
    }

    public void RefreshPanel()
    {
        foreach (Transform child in recruitmentGrid)
        {
            Destroy(child.gameObject); // Clear existing agent cards
        }

        StartCoroutine(InitializeRecruitmentPanel());
    }
}
