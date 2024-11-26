using UnityEngine;

public class AgentUI : MonoBehaviour
{
    public AgentSO agentSO; // The central data point for the agent

    [SerializeField] private GameObject cardView;
    [SerializeField] private GameObject detailedView;

    private void Start()
    {
        // Ensure the default view is the card view
        SetViewMode(true);
    }

    public void SetViewMode(bool isCardView)
    {
        if (cardView != null && detailedView != null)
        {
            cardView.SetActive(isCardView);
            detailedView.SetActive(!isCardView);
        }
        else
        {
            Debug.LogWarning("CardView or DetailedView is not assigned in AgentUI.");
        }
    }
}
