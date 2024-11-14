using UnityEngine;

public class UIRecruitButton : MonoBehaviour
{
    [SerializeField] private AgentSO agentSO;
    [SerializeField] private UIPanelFiller filler;
     
    void Start()
    {
        //agentSO = GetComponentInParent<UIRecruitmentScreen>().getAgentSO();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void recruitAgent()
    {
        agentSO = GetComponentInParent<UIRecruitmentScreen>().getAgentSO();
        if (agentSO != null)
        {
            AgentManager.Instance.RecruitAgent(agentSO);
            filler.refreshAgentSOs();
            filler.fillAgentPanels();
            GetComponentInParent<UIRecruitmentScreen>().setAgentSO(null);
        }

    }

}
