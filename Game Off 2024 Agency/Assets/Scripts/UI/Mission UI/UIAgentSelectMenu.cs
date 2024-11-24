using UnityEngine;
using System.Collections.Generic;

public class UIAgentSelectMenu : MonoBehaviour
{
    [SerializeField] private Mission mission;
    [SerializeField] private List<Agent> avaiableAgents = new List<Agent>();

    public Mission Mission { get => mission; set => mission = value; }
    public List<Agent> AvaiableAgents { get => avaiableAgents; set => avaiableAgents = value; }
    public void onEnable()
    {
        AvaiableAgents = AgentManager.Instance.activeAgents;
    }

}   
