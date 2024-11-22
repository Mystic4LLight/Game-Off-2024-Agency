using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ArtifactUI : MonoBehaviour
{
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

    private ArtifactSO currentArtifact;
    [SerializeField] private TextMeshProUGUI researchTimeText;

    public void DisplayArtifact(ArtifactSO artifactSO, bool isIdentified)
    {
        currentArtifact = artifactSO;

        if (!isIdentified)
        {
            unidentifiedPanel.SetActive(true);
            identifiedPanel.SetActive(false);
            unidentifiedNameText.text = artifactSO.unidentifiedName; // Placeholder name
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
        return artifact.hasCurse ? "Cursed - Negative Effect" : "Blessed - Positive Effect";
    }

    private void UpdateUsagePage()
    {
        usageNameText.text = currentArtifact.displayName;
        profileImage.sprite = currentArtifact.profilePhoto;
    }

    public void InitializeUI(Artifact artifact)
    {
        if (artifact != null)
        {
            researchTimeText.text = $"Time Left: {artifact.GetRemainingResearchTime()} hours";

            if (artifact.artifactSO.hasCurse)
            {
                // Display curse information on the UI
            }
        }
    }

    public void OnResearchButtonClick()
    {
        if (currentArtifact != null)
        {
            artifact.ReduceResearchTime(24f);  // Reduce research time by 24 hours for a "day".
            UpdateResearchTimerUI();           // Update UI with the new time.

            if (artifact.GetRemainingResearchTime() <= 0)
            {
                artifact.Identify();  // Mark artifact as identified.
                DisplayArtifact(currentArtifact, true); // Update UI to show identified artifact
            }
        }
}
}
