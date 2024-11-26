using UnityEngine;
using System.Collections.Generic;

// Draft Template for a mission class (needed for Artifacts script as a draft)
[System.Serializable]
public class Mission
{
    [SerializeField] private List<Agent> _agents;

    [SerializeField] private List<Artifact> _artifacts = new List<Artifact>();

    public bool AddArtifact(Artifact artifact)
    {
        if (!_artifacts.Contains(artifact))
        {
            _artifacts.Add(artifact);
            GameLogger.Log($"Artifact {artifact.name} was added to the mission.");
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
}
