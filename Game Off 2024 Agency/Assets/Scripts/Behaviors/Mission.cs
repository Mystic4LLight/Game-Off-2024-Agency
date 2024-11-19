using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


// Draft Template for a mission class (needed for Artifacts script as a draft)
[System.Serializable]
public class Mission : MonoBehaviour
{
    [SerializeField] private List<Agent> _agents;

    [SerializeField] private List<Artifact> _artifacts = new List<Artifact>();
    [SerializeField] private string missionName;
    [SerializeField] private string description;
    [SerializeField] private int passCheck;
    [SerializeField] public Sprite missionImage;
    [SerializeField] private MissionSO missionSO;

    public global::System.String MissionName { get => missionName; set => missionName = value; }
    public global::System.String Description { get => description; set => description = value; }
    public global::System.Int32 PassCheck { get => passCheck; set => passCheck = value; }
    public Sprite MissionImage { get => missionImage; set => missionImage = value; }
    public MissionSO MissionSO { get => missionSO; set => missionSO = value; }

    public void OnEnable()
    {
        missionName = missionSO.missionName;
        description = missionSO.description;
        passCheck = missionSO.passCheck;
        missionImage = missionSO.missionImage;
    }

    public bool AddArtifact(Artifact artifact)
    {
        if (!_artifacts.Contains(artifact))
        {
            _artifacts.Add(artifact);
            Debug.Log($"Artifact {artifact.name} was added to the mission.");
            return true;
        }
        else
            return false;
    }

    public bool RemoveArtifact(Artifact artifact)
    {
        if (_artifacts.Contains(artifact))
        {
            return _artifacts.Remove(artifact);
        }
        else
            return false;
    }
    public bool AddAgent(Agent agent)
    {
        if (!_agents.Contains(agent))
        {
            _agents.Add(agent);
            return true;
        }
        else
            return false;
    }
    public bool removeAgent (Agent agent)
    {
        if (_agents.Contains(agent))
        {
            return _agents.Remove(agent);
        }
        else
            return false;
    }
}
