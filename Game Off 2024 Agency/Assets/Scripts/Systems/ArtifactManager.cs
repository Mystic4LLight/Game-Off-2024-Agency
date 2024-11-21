using UnityEngine;
using System.Collections.Generic;
using System.Reflection;


public class ArtifactManager : MonoBehaviour
{
    public static ArtifactManager Instance;

    // A list of artifact templates (ScriptableObjects) that will be assigned in the Unity Editor.
    public List<ArtifactSO> artifactSO_Templates;

    // Template for an unidentified artifact.(shows to player if artifact is not identified)
    public ArtifactSO unidentifiedArtifactSO;

    // The artifact prefab to be instantiated when creating new artifacts.
    [SerializeField] Artifact artifactPrefab;

    // A comprehensive list of all artifacts existing within the game.
    [SerializeField] public List<Artifact> agencyArtifactCatalog = new List<Artifact>();

    // A list of artifacts currently owned by the agency (acquired or starting artifacts).
    [SerializeField] public List<Artifact> agencyOwnedArtifacts = new List<Artifact>();

    // A list of artifacts currently stored at the agency's headquarters (some artifacts may be taken on active missions).
    [SerializeField] public List<Artifact> headquartersStoredArtifacts = new List<Artifact>();

    // A list of artifacts assigned to active missions.
    [SerializeField] public List<Artifact> missionAssignedArtifacts = new List<Artifact>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        InitializeArtifactCatalog();

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "CorrisScene-Sandbox")
        {
            //=======================
            // TEST PART

            Debug.Log("TEST Adding Random artifacts to catalog and identifying one of it");
            // Add new artifact to Agency
            var newOwnedArtifact = AddRandomArtifactToAgency();
            IdentifyArtifact(newOwnedArtifact);
            // Add another artifact to agency - but without identification
            AddRandomArtifactToAgency();
            // Log the contents of the artifact catalog.
            /*     foreach (var artifact in agencyArtifactCatalog)
                {
                    Debug.Log("<color=blue>Artifact: " + artifact.name + " Address: " + artifact.GetInstanceID() + "</color>");
                }   
           */
            //=======================
        }
    }

    private void InitializeArtifactCatalog()
    {
        // Clear the existing catalog to avoid duplicates.
        agencyArtifactCatalog.Clear();

        // Iterate through each template in artifactSO_Templates.
        foreach (var template in artifactSO_Templates)
        {
            // Call the InitializeArtifact method for each template.
            InitializeArtifact(template);
        }

        // Log with Green color Artifact Catalog filled with the number of artifacts.
        Debug.Log("<color=yellow>Artifact Catalog filled with " + agencyArtifactCatalog.Count + " artifacts.</color>");
    }

    private void InitializeArtifact(ArtifactSO template)
    {
        // Instantiate a new artifact using the artifactPrefab as a child of the ArtifactManager.
        Artifact newArtifact = Instantiate(artifactPrefab, this.transform);

        // InitializeAgentStats the new artifact with the template's data.
        newArtifact.InitializeFromTemplate(template);

        // Add the new artifact to the agencyArtifactCatalog.
        agencyArtifactCatalog.Add(newArtifact);
    }

    public void AddNewArtifactToAgency(Artifact artifact)
    {
        agencyOwnedArtifacts.Add(artifact);
        headquartersStoredArtifacts.Add(artifact);
        Debug.Log("<color=purple>New artifact '" + artifact.name + "' added to headquarters storage.</color>");
    }

    // TEST Function to check Artifacts working
    private Artifact AddRandomArtifactToAgency()
    {
        if (agencyArtifactCatalog.Count > 0)
        {
            int randomIndex = Random.Range(0, agencyArtifactCatalog.Count);
            var randomArtifact = agencyArtifactCatalog[randomIndex];
            AddNewArtifactToAgency(randomArtifact);
            return randomArtifact;
        }
        else
        {
            Debug.LogWarning("Artifact catalog is empty. Cannot add a random artifact to the agency.");
            return null;
        }
    }
    public void IdentifyArtifact(Artifact artifact)
    {
        artifact.Identify();
    }

    public bool AssignArtifactToMission(Artifact artifact, Mission mission)
    {
        if (headquartersStoredArtifacts.Contains(artifact))
        {
            headquartersStoredArtifacts.Remove(artifact);
            missionAssignedArtifacts.Add(artifact);
            mission.AddArtifact(artifact);
            return true;
        }
        else
        {
            Debug.LogWarning("Artifact not found in headquarters storage.");
            return false;
        }
    }

    public bool ReturnArtifactFromMission(Artifact artifact, Mission mission)
    {
        if (missionAssignedArtifacts.Contains(artifact))
        {
            missionAssignedArtifacts.Remove(artifact);
            headquartersStoredArtifacts.Add(artifact);
            mission.RemoveArtifact(artifact);
            return true;
        }
        else
        {
            Debug.LogWarning("Artifact not found in mission assigned artifacts.");
            return false;
        }
    }

}
