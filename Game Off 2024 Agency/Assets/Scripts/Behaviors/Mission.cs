using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mission : MonoBehaviour
{
    public string missionName;
    public string description;
    public int passCheck;
    public enum attributesForCheck{
        Strength,
        Agility,
        Intelligence
    }
    public attributesForCheck missionAttribute;
    public List<Agent> deployedAgents = new List<Agent>();
    public MissionSO missionSO;
    void Start()
    {
        name = missionSO.missionName;
        description = missionSO.description;
        passCheck = missionSO.passCheck;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void deployAgent(Agent agent){
        deployedAgents.Add(agent);
    }

}
