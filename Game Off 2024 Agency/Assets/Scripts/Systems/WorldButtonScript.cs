using UnityEngine;
using System.Collections.Generic;
using System.Collections;

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
    [SerializeField] private AgentPoolManager agentPoolManager; // Reference to the AgentPoolManager

    void Start()
    {
        buttonRenderer = GetComponent<Renderer>();
        originalColor = buttonRenderer.material.color;
    }

    void Update()
    {
        if (UIManager.IsCameraBlocked())
            return; // Block camera movement when UI windows are active

        if (isHovered && Input.GetMouseButtonDown(0))
        {
            OnWorldButtonClicked();
        }
    }

    void OnMouseEnter()
    {
        if (UIManager.IsCameraBlocked())
            return; // Block camera movement when UI windows are active

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
        if (UIManager.IsCameraBlocked())
            return; // Block camera movement when UI windows are active

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

        UpdateAgentButtonsForRoom();
    }

    private void UpdateAgentButtonsForRoom()
    {
        // Move agents to the room pool if conditions are met and deactivate the select button if necessary
        for (int i = 0; i < agents.Count; i++)
        {
            var agent = agents[i];
            if (agent == null) continue;

            var agentComponent = agent.GetComponent<Agent>();
            if (agentComponent == null) continue;

            // Check if the agent is under treatment or assigned elsewhere
            if (agentComponent.agentSO != null && agentComponent.agentSO.isOnTreatment)
            {
                // Move the agent to the Med Bay container and deactivate the select button
                agentPoolManager.MoveAgentToRoom(agent, agentPoolManager.GetRoomContainer("MedBay"));
                selectAgentButtons[i].gameObject.SetActive(false);
            }
            else
            {
                // Move agent back to the available pool if not assigned and activate the select button
                agentPoolManager.MoveAgentToAvailablePool(agent);
                selectAgentButtons[i].gameObject.SetActive(true);
            }
        }
    }
}
