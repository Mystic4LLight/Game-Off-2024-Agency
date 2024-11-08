using System.Collections.Generic;
using UnityEngine;

public class RecruitAgentButton : MonoBehaviour
{
    [SerializeField] private List<AgentPanel> agentPanels = new List<AgentPanel>();
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void recruitAgentButtonPressed(){
        foreach (AgentPanel agentPanel in agentPanels)
        if (agentPanel.isClicked == true && agentPanel.agentSO != null){
            AgentManager.Instance.RecruitAgent(agentPanel.agentSO);
            agentPanel.isClicked = false;
        }
        
    }
}
