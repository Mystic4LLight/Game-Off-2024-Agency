using UnityEngine;
using UnityEngine.UI;

public class SelectAgentButton : MonoBehaviour
{
    private GameObject parentAgentObject;
    private bool isInitialized = false;
    private Button buttonComponent;
    private AgentSO agentSO;

    private void Awake()
    {
        // Register with the UIInitializationManager if the instance exists
        if (UIInitializationManager.Instance != null)
        {
            UIInitializationManager.Instance.RegisterAgentButton(this);
        }
        else
        {
            GameLogger.LogWarning($"UIInitializationManager instance is null. Button {gameObject.name} could not be registered.");
        }

        // Get the Button component attached to this GameObject
        buttonComponent = GetComponent<Button>();
        if (buttonComponent != null)
        {
            buttonComponent.onClick.AddListener(OnButtonClick);
        }
        else
        {
            GameLogger.LogError($"SelectAgentButton: No Button component found on {gameObject.name}.");
        }
    }

    private void OnEnable()
    {
        if (parentAgentObject != null && !isInitialized)
        {
            InitializeButton();
            GameLogger.Log($"SelectAgentButton initialized after activation for {parentAgentObject.name}");
        }
        else
        {
            GameLogger.LogWarning("SelectAgentButton is active but parentAgentObject is not assigned or already initialized.");
        }
    }

    public void SetParentAgentObject(GameObject agentObject)
    {
        parentAgentObject = agentObject;
        agentSO = agentObject.GetComponent<AgentUI>()?.agentSO;

        if (gameObject.activeInHierarchy && !isInitialized)
        {
            InitializeButton();
            GameLogger.Log($"SelectAgentButton initialized for agent: {agentObject.name}");
        }
        else
        {
            GameLogger.LogWarning("SelectAgentButton is inactive or already initialized. Delaying initialization until it becomes active.");
        }
    }

    public void InitializeButton()
    {
        if (parentAgentObject == null || agentSO == null)
        {
            GameLogger.LogError("InitializeButton: parentAgentObject or agentSO is null. Cannot initialize button.");
            return;
        }

        // Place button initialization logic here
        isInitialized = true;
        UpdateButtonState();
        GameLogger.Log($"SelectAgentButton: Button initialized for agent: {parentAgentObject.name}");
    }

    public void OnButtonClick()
    {
        if (parentAgentObject == null || agentSO == null)
        {
            GameLogger.LogError("OnButtonClick: parentAgentObject or agentSO is null. Cannot proceed with click action.");
            return;
        }

        if (agentSO.isOnTreatment)
        {
            GameLogger.LogWarning($"{agentSO.agentName} is currently under treatment. Selection is disabled.");
            return;
        }

        GameLogger.Log($"SelectAgentButton: Button clicked for agent: {parentAgentObject.name}");

        if (UIInitializationManager.Instance != null)
        {
            UIInitializationManager.Instance.SetCurrentAgent(parentAgentObject);
            GameLogger.Log($"SelectAgentButton: Assigned agent {parentAgentObject.name} to UIInitializationManager.");
        }
        else
        {
            GameLogger.LogError("OnButtonClick: UIInitializationManager instance is null. Cannot assign agent.");
        }
    }

    private void UpdateButtonState()
    {
        // Update button interactable state based on the agent's status
        if (agentSO != null && agentSO.isOnTreatment)
        {
            buttonComponent.interactable = false;
            gameObject.SetActive(false);
        }
        else
        {
            buttonComponent.interactable = true;
            gameObject.SetActive(true);
        }
    }
}
