using UnityEngine;
using System.Collections.Generic;

public class ActiveAgentsMenu : MonoBehaviour
{
    [SerializeField] private List<UIAgentFile> agentPanels = new List<UIAgentFile>();
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
            //agentPanels[i].agentSO = AgentManager.Instance.activeAgents[i].getAgentSO();
            //if (agentPanels[i].getAgentSO != null){
                //agentPanels[i].fillPanel();
            //}
        }
    }

}
