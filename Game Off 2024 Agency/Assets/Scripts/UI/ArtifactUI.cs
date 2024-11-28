using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ArtifactUI : MonoBehaviour
{
    public ArtifactSO artifactSO { get; private set; }

    [SerializeField] private Artifact artifact;
    [Header("Panels")]
    [SerializeField] private GameObject unidentifiedPanel;
    [SerializeField] private GameObject identifiedPanel;

    [Header("Unidentified Artifact UI")]
    [SerializeField] private TMP_Text unidentifiedNameText;
    [SerializeField] private TMP_Text researchTimerText;
    [SerializeField] private Button researchButton;

    [Header("Identified Artifact UI - Info Page")]
    [SerializeField] private TMP_Text identifiedNameText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private TMP_Text effectText; // for positive or negative effects
    [SerializeField] private Button toggleUsagePageButton;

    [Header("Identified Artifact UI - Usage Page")]
    [SerializeField] private TMP_Text usageNameText;
    [SerializeField] private Image profileImage;

    [Header("Cursed Artifact UI")]
    [SerializeField] private TMP_Text cursedStatusText;
    [SerializeField] private TMP_Text cursedDetailsText;

    private ArtifactSO currentArtifact;
    [SerializeField] private TextMeshProUGUI researchTimeText;

    public void UpdateArtifactUI(ArtifactSO artifactSO)
    {
        identifiedNameText.text = artifactSO.artifactName;  // Change to identifiedNameText
        descriptionText.text = artifactSO.description;

        // Check if artifact is cursed and update UI accordingly
        if (artifactSO.isCursed)
        {
            cursedStatusText.text = "Cursed Artifact"; // Add a specific UI element for curses
            cursedStatusText.color = Color.red; // Optional: change text color to indicate danger

            // List all curses
            string curseDescriptions = "";
            foreach (var curse in artifactSO.cursedEffects)
            {
                curseDescriptions += $"- {curse.effectName}: {curse.description}\n";
            }
            cursedDetailsText.text = curseDescriptions;
        }
        else
        {
            cursedStatusText.text = "Not Cursed";
            cursedDetailsText.text = "";
        }
    }


    public void DisplayArtifact(ArtifactSO artifactSO, bool isIdentified)
    {
        currentArtifact = artifactSO;

        if (!isIdentified)
        {
            unidentifiedPanel.SetActive(true);
            identifiedPanel.SetActive(false);
            unidentifiedNameText.text = artifactSO.unidentifiedName;
            researchTimerText.text = $"Time Left: {artifact.GetRemainingResearchTime()} hours";
            UpdateResearchTimerUI();
        }
        else
        {
            unidentifiedPanel.SetActive(false);
            identifiedPanel.SetActive(true);
            identifiedNameText.text = artifactSO.displayName;
            descriptionText.text = artifactSO.description;
            effectText.text = GetArtifactEffectText(artifactSO);
            UpdateUsagePage();
        }
    }

    private void UpdateResearchTimerUI()
    {
        researchTimerText.text = "Time Left: " + artifact.GetRemainingResearchTime();
    }

    private string GetArtifactEffectText(ArtifactSO artifact)
    {
        return artifact.isCursed ? "Cursed - Negative Effect" : "Blessed - Positive Effect";
    }

    private void UpdateUsagePage()
    {
        usageNameText.text = currentArtifact.displayName;
        profileImage.sprite = currentArtifact.profilePhoto;
    }

    public void InitializeUI(Artifact artifact)
    {
        if (artifact == null)
        {
            GameLogger.LogError("Artifact is null!");
            return;
        }

        artifactSO = artifact.artifactSO; // Ensure the artifactSO is assigned properly.
        researchTimeText.text = $"Time Left: {artifact.GetRemainingResearchTime()} hours";

        if (artifactSO != null && artifactSO.isCursed)
        {
            GameLogger.Log($"Artifact '{artifactSO.displayName}' is cursed!");
            // Display curse-related information on the UI
        }
    }

    public void OnResearchButtonClick()
    {
        if (currentArtifact != null)
        {
            artifact.ReduceResearchTime(Mathf.FloorToInt(24f)); // Convert float to int
            UpdateResearchTimerUI();           // Update UI with the new time.

            if (artifact.GetRemainingResearchTime() <= 0)
            {
                artifact.Identify();  // Mark artifact as identified.
                DisplayArtifact(currentArtifact, true); // Update UI to show identified artifact
            }
        }
}
}
