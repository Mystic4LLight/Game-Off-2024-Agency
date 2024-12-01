using UnityEngine;
using System.Collections.Generic;

public class WorldButtonScript : MonoBehaviour
{
    public GameObject targetWindow;  // The window that the world button will open
    private Renderer buttonRenderer;  // To change the button's color on hover and click
    public Color hoverColor = Color.green;  // Color when mouse hovers
    public Color clickColor = Color.blue;  // Color when mouse clicks
    private Color originalColor;  // Store the original color of the button
    private bool isHovered = false; // Track if the player is hovering over the button

    [SerializeField] private List<SelectAgentButton> selectAgentButtons; // References to the SelectAgentButton components
    [SerializeField] private List<GameObject> agents; // List of agent GameObjects

    void Start()
    {
        buttonRenderer = GetComponent<Renderer>();
        originalColor = buttonRenderer.material.color;
    }

    void Update()
    {
        if (isHovered && Input.GetMouseButtonDown(0)) 
        {
            OnWorldButtonClicked();
        }
    }

    void OnMouseEnter()
    {
        isHovered = true;
        buttonRenderer.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        isHovered = false;
        buttonRenderer.material.color = originalColor;
    }

    public void OnWorldButtonClicked()
    {
        GameLogger.Log("World Window Opened!");

        // Ensure that the window is opened through the UIManager
        if (targetWindow != null)
        {
            UIManager.Instance.OpenWindow(targetWindow); // Use UIManager to open the window
        }
        else
        {
            GameLogger.LogWarning("Target window reference is null.");
            return;
        }

        // Initialize agent buttons if available
        if (selectAgentButtons.Count != agents.Count)
        {
            GameLogger.LogWarning("Mismatch between the number of selectAgentButtons and agents.");
            return;
        }

        for (int i = 0; i < agents.Count; i++)
        {
            if (agents[i] != null && selectAgentButtons[i] != null)
            {
                if (!selectAgentButtons[i].gameObject.activeInHierarchy)
                {
                    selectAgentButtons[i].gameObject.SetActive(true);
                }

                // Ensure the agent object is properly assigned to the button before initialization
                InitializeSelectButton(selectAgentButtons[i], agents[i]);
            }
            else
            {
                GameLogger.LogWarning("SelectAgentButton or agent reference is null for index " + i);
            }
        }
    }

private void InitializeSelectButton(SelectAgentButton buttonComponent, GameObject agent)
{
    if (buttonComponent != null && agent != null)
    {
        buttonComponent.SetParentAgentObject(agent);
        GameLogger.Log($"Activating and initializing SelectAgentButton for agent: {agent.name}");
    }
    else
    {
        GameLogger.LogWarning("Initialization failed: SelectAgentButton or agent is null.");
    }
}
}