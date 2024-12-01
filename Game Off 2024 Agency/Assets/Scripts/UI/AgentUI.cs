using UnityEngine;

public class AgentUI : MonoBehaviour
{
    public AgentSO agentSO; // The central data point for the agent

    [SerializeField] private GameObject cardView;      // The card view of the agent
    [SerializeField] private GameObject detailedView;  // The detailed view (AgentPanel)
    private Canvas overlayCanvas;                     // The overlay canvas for detailed views
    private Transform originalParent;                 // To store the original parent of the detailed view

    private void Start()
    {
        // Find the OverlayCanvas in the scene
        overlayCanvas = Object.FindAnyObjectByType<Canvas>(); // Alternative to the deprecated FindObjectOfType
        if (overlayCanvas == null)
        {
            GameLogger.LogError("OverlayCanvas not found in the scene. Ensure an OverlayCanvas exists.");
            return;
        }

        // Ensure the default view is the card view
        SetViewMode(true);
    }

    // Method to set the AgentSO
    public void SetAgentSO(AgentSO agent)
    {
        agentSO = agent;
    }

    // Method to provide the AgentSO reference
    public AgentSO GetAgentSO()
    {
        return agentSO;
    }

    public void SetViewMode(bool isCardView)
    {
        if (cardView != null && detailedView != null)
        {
            cardView.SetActive(isCardView);
            detailedView.SetActive(!isCardView);

            if (!isCardView) // When switching to detailed view
            {
                if (overlayCanvas == null)
                {
                    GameLogger.LogError("OverlayCanvas is missing. Cannot display detailed view.");
                    return;
                }

                // Store the original parent
                originalParent = detailedView.transform.parent;

                // Move detailedView to the overlay canvas
                detailedView.transform.SetParent(overlayCanvas.transform, false);

                // Center the detailedView in the overlay canvas
                RectTransform rectTransform = detailedView.GetComponent<RectTransform>();
                if (rectTransform != null)
                {
                    rectTransform.anchoredPosition = Vector2.zero; // Center it
                }
                else
                {
                    GameLogger.LogWarning("DetailedView does not have a RectTransform.");
                }
            }
            else if (originalParent != null) // When switching back to card view
            {
                // Restore the original parent
                detailedView.transform.SetParent(originalParent, false);
            }
        }
        else
        {
            
    if (cardView == null || detailedView == null)
    {
        GameLogger.LogWarning("CardView or DetailedView is not assigned in AgentUI. Cannot switch views.");
        return;
    }
    
        }
    }

    public void OnCardClicked()
    {
        SetViewMode(false); // Switch to detailed view
    }

    public void OnCloseDetailedView()
    {
        SetViewMode(true); // Switch back to card view
    }

    public void CopyStatsFrom(AgentUI original)
    {
        if (original == null)
        {
            
        if (original == null)
        {
            GameLogger.LogWarning("Original AgentUI is null. Cannot copy stats.");
            return;
        }
        if (agentSO == null)
        {
            GameLogger.LogError("AgentSO reference in the current AgentUI is null. Cannot copy stats.");
            return;
        }
        
            return;
        }

        // Copy all stats, abilities, health, sanity, etc.
        agentSO = original.agentSO;

        // If there are other stats or components to copy, add them here
        // Example: Copy other runtime-updated data, such as HP, sanity, special effects, etc.
        // Assuming these stats are part of AgentSO or directly in AgentUI.
        // Add any code necessary for a complete copy of runtime information.
    }
}
