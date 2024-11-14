using System.Collections.Generic;
using System.Linq;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class UIAgentPanel : MonoBehaviour
{
    [SerializeField] private UIAgentPortrait agentPortrait;
    private AgentSO agentSO;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public AgentSO getAgentSO()
    {
        return agentSO;
    }
    public void setAgentSO(AgentSO newAgentSO)
    {
        agentSO = newAgentSO; 
    }
    public void setAgentProfilePicture()
    {
        if (agentSO != null)
        {
            agentPortrait.transform.gameObject.GetComponent<Image>().sprite = agentSO.profilePhoto;
        }
        else
        {
            agentPortrait.transform.gameObject.GetComponent<Image>().sprite = null;
        }
    }

}
