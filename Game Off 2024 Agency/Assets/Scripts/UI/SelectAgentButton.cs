using UnityEngine;
using UnityEngine.UI;

public class SelectAgentButton : MonoBehaviour
{
    private GameObject parentAgentObject;
    private bool isInitialized = false;
    private Button buttonComponent;

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
        // Ensure parentAgentObject is not null
        if (parentAgentObject == null)
        {
            GameLogger.LogError("InitializeButton: parentAgentObject is null. Cannot initialize button.");
            return;
        }

        // Place button initialization logic here
        isInitialized = true;
        GameLogger.Log($"SelectAgentButton: Button initialized for agent: {parentAgentObject.name}");
    }

    public void OnButtonClick()
    {
        if (parentAgentObject == null)
        {
            GameLogger.LogError("OnButtonClick: parentAgentObject is null. Cannot proceed with click action.");
            return;
        }

        GameLogger.Log($"SelectAgentButton: Button clicked for agent: {parentAgentObject.name}");

        // Pass the agent to the manager
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

    public bool IsInitialized()
    {
        return isInitialized;
    }
}
