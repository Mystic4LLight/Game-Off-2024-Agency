using UnityEngine;

public class UIInitializationManager : MonoBehaviour
{
    public static UIInitializationManager Instance;

    [SerializeField]
    private RecruitAgentButtonHandler recruitButtonHandler;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            GameLogger.Log("UIInitializationManager initialized and set to persist across scenes.");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterAgentButton(SelectAgentButton button)
    {
        // Registration logic for agent buttons
        GameLogger.Log($"UIInitializationManager: Registered SelectAgentButton for initialization.");
    }

    public void SetCurrentAgent(GameObject agent)
    {
        if (recruitButtonHandler != null)
        {
            recruitButtonHandler.SetAgent(agent);
            GameLogger.Log($"UIInitializationManager: Set current agent {agent.name} in RecruitAgentButtonHandler.");
        }
        else
        {
            GameLogger.LogError("UIInitializationManager: recruitButtonHandler is null. Cannot assign agent.");
        }
    }
}
