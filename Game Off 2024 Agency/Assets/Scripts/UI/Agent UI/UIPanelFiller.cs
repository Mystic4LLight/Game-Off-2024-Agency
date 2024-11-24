using System.Collections.Generic;
using UnityEngine;

public class UIPanelFiller : MonoBehaviour
{
    [SerializeField] private List<UIAgentPanel> agentPanels = new List<UIAgentPanel>();
    [SerializeField] private List<AgentSO> agentSOs = new List<AgentSO>();

    private void OnEnable()
    {
        
        fillAgentPanels();
    }
    public void fillAgentPanels()
    {
        for (int i = 0; i < agentPanels.Count; i++)
        {
            if (i < agentSOs.Count)
            {
                agentPanels[i].setAgentSO(agentSOs[i]);
                agentPanels[i].setAgentProfilePicture();
            }
            else
            {
                agentPanels[i].setAgentSO(null);
                agentPanels[i].setAgentProfilePicture();
            }
        }
    }
    public void refreshAgentSOs()
    {
        agentSOs = AgentManager.Instance.recruitableAgentsSO;
    }

}
