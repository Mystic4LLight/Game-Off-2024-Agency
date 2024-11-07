using UnityEngine;
using System.Collections.Generic;

public class ActiveAgentsMenu : MonoBehaviour
{
    [SerializeField] private List<AgentPanel> agentPanels = new List<AgentPanel>();
    void OnEnable(){
        FillAgents();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FillAgents(){
        for (int i = 0; i < AgentManager.Instance.activeAgents.Count; i++){
            agentPanels[i].agentSO = AgentManager.Instance.activeAgents[i].agentSO;
            if (agentPanels[i].agentSO != null){
                agentPanels[i].fillPanel();
            }
        }
    }

}
