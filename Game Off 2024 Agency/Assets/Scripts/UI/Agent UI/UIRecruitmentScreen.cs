using UnityEngine;

public class UIRecruitmentScreen : MonoBehaviour
{
    [SerializeField] private AgentSO agentSO;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setAgentSO(AgentSO newAgentSO)
    {
        agentSO = newAgentSO;
    }
    public AgentSO getAgentSO()
    {
        return agentSO;
    }

}
