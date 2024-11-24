using System.Collections.Generic;
using UnityEngine;

public class RecruitAgentButton : MonoBehaviour
{
    [SerializeField] private List<UIAgentFile> agentPanels = new List<UIAgentFile>();
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void recruitAgentButtonPressed(){
        //foreach (UIAgentFile agentPanel in agentPanels)
        //if (agentPanel.isClicked == true && agentPanel.getAgentSO() != null){
            //AgentManager.Instance.RecruitAgent(agentPanel.getAgentSO());
            //agentPanel.isClicked = false;
        //}
        
    }
}
