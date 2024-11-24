using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AgentPanel : MonoBehaviour
{
    private Dictionary<Specialization.SpecializationType, List<TextMeshProUGUI>> placeholderNameText = new();
    private Dictionary<Specialization.SpecializationType, List<TextMeshProUGUI>> placeholderValueText = new();
    private Dictionary<Specialization.SpecializationType, List<string>> defaultPlaceholderText = new();

    public AgentSO agentSO;

    [Header("Agent Information")]
    public TextMeshProUGUI agentNameText, agentOccupationText, agentAgeText, agentSexText, agentBackstoryText;

    [Header("Portrait")]
    public Image portraitImage;

    [Header("Characteristics")]
    public TextMeshProUGUI strengthText, constitutionText, sizeText, dexterityText, appearanceText;
    public TextMeshProUGUI educationText, intelligenceText, powerText;

    [Header("Bar Stats UI")]
    public Image hpFillBar, mpFillBar, sanFillBar, luckFillBar;
    public TextMeshProUGUI hpText, mpText, sanText, luckText;

    [Header("Specialization Placeholders")]
    public TextMeshProUGUI artCraftNameText, artCraftValueText, artCraft2NameText, artCraft2ValueText, artCraft3NameText, artCraft3ValueText;
    public TextMeshProUGUI fighting2NameText, fighting2ValueText, fighting3NameText, fighting3ValueText;
    public TextMeshProUGUI firearms3NameText, firearms3ValueText;
    public TextMeshProUGUI scienceNameText, scienceValueText, science2NameText, science2ValueText, science3NameText, science3ValueText;
    public TextMeshProUGUI languageOtherNameText, languageOtherValueText, language2NameText, language2ValueText, languageOwnNameText, languageOwnValueText;
    public TextMeshProUGUI other1NameText, other1ValueText, other2NameText, other2ValueText, other3NameText, other3ValueText;
    public TextMeshProUGUI other4NameText, other4ValueText, other5NameText, other5ValueText;
    [Header("Survival Specialization")]
    public TextMeshProUGUI survivalNameText;
    public TextMeshProUGUI survivalValueText;

    public AgentSO AgentSO => agentSO;

    private bool _isClicked = false;
    public bool isClicked
    {
        get => _isClicked;
        private set => _isClicked = value;
    }

    private void OnEnable()
    {
        // Initialize placeholder dictionaries
        placeholderNameText.Clear();
        placeholderValueText.Clear();
        InitializeDefaultPlaceholderText();
        InitializePlaceholders();
    }

    private void InitializeDefaultPlaceholderText()
    {
        defaultPlaceholderText[Specialization.SpecializationType.Science] = new List<string>
        {
            "Science\n----", "----", "----"
        };

        defaultPlaceholderText[Specialization.SpecializationType.ArtCraft] = new List<string>
        {
            "Art/Craft\n----", "----", "----"
        };

        defaultPlaceholderText[Specialization.SpecializationType.Language] = new List<string>
        {
            "Language(Other)\n----", "----", "Language(Own)\nEnglish"
        };

        defaultPlaceholderText[Specialization.SpecializationType.Fighting] = new List<string>
        {
            "Fighting\n----", "Fighting\n----"
        };

        defaultPlaceholderText[Specialization.SpecializationType.Firearms] = new List<string>
        {
            "Firearms\n----"
        };

        defaultPlaceholderText[Specialization.SpecializationType.Other] = new List<string>
        {
            "----", "----", "----", "----", "----"
        };

        defaultPlaceholderText[Specialization.SpecializationType.Survival] = new List<string>
        {
            "Survival\n----"
        };
    }

    private void InitializePlaceholders()
    {
        // Art/Craft placeholders
        placeholderNameText[Specialization.SpecializationType.ArtCraft] = new List<TextMeshProUGUI>
        {
            artCraftNameText, artCraft2NameText, artCraft3NameText
        };
        placeholderValueText[Specialization.SpecializationType.ArtCraft] = new List<TextMeshProUGUI>
        {
            artCraftValueText, artCraft2ValueText, artCraft3ValueText
        };

        // Fighting placeholders
        placeholderNameText[Specialization.SpecializationType.Fighting] = new List<TextMeshProUGUI>
        {
            fighting2NameText, fighting3NameText
        };
        placeholderValueText[Specialization.SpecializationType.Fighting] = new List<TextMeshProUGUI>
        {
            fighting2ValueText, fighting3ValueText
        };

        // Firearms placeholders
        placeholderNameText[Specialization.SpecializationType.Firearms] = new List<TextMeshProUGUI>
        {
            firearms3NameText
        };
        placeholderValueText[Specialization.SpecializationType.Firearms] = new List<TextMeshProUGUI>
        {
            firearms3ValueText
        };

        // Science placeholders
        placeholderNameText[Specialization.SpecializationType.Science] = new List<TextMeshProUGUI>
        {
            scienceNameText, science2NameText, science3NameText
        };
        placeholderValueText[Specialization.SpecializationType.Science] = new List<TextMeshProUGUI>
        {
            scienceValueText, science2ValueText, science3ValueText
        };

        // Language placeholders
        placeholderNameText[Specialization.SpecializationType.Language] = new List<TextMeshProUGUI>
        {
            languageOtherNameText, language2NameText, languageOwnNameText
        };
        placeholderValueText[Specialization.SpecializationType.Language] = new List<TextMeshProUGUI>
        {
            languageOtherValueText, language2ValueText, languageOwnValueText
        };

        // Other placeholders
        placeholderNameText[Specialization.SpecializationType.Other] = new List<TextMeshProUGUI>
        {
            other1NameText, other2NameText, other3NameText, other4NameText, other5NameText
        };
        placeholderValueText[Specialization.SpecializationType.Other] = new List<TextMeshProUGUI>
        {
            other1ValueText, other2ValueText, other3ValueText, other4ValueText, other5ValueText
        };

        // Survival placeholder
        placeholderNameText[Specialization.SpecializationType.Survival] = new List<TextMeshProUGUI>
        {
            survivalNameText
        };
        placeholderValueText[Specialization.SpecializationType.Survival] = new List<TextMeshProUGUI>
        {
            survivalValueText
        };

        ResetPlaceholdersToDefault();
    }

    private void ResetPlaceholdersToDefault()
    {
        foreach (var type in placeholderNameText.Keys)
        {
            if (defaultPlaceholderText.TryGetValue(type, out var defaultTexts))
            {
                for (int i = 0; i < placeholderNameText[type].Count; i++)
                {
                    placeholderNameText[type][i].text = i < defaultTexts.Count ? defaultTexts[i] : "----";
                }
            }
            foreach (var valueText in placeholderValueText[type])
            {
                valueText.text = ""; // Clear value
            }
        }
    }

    public void UpdateUI()
    {
        if (agentSO == null)
        {
            Debug.LogWarning("No AgentSO assigned to AgentPanel.");
            return;
        }

        // Update agent information
        agentNameText.text = agentSO.agentName;
        agentOccupationText.text = agentSO.agentOccupation;
        agentAgeText.text = agentSO.agentAge.ToString();
        agentSexText.text = agentSO.agentSex;
        agentBackstoryText.text = agentSO.agentBackstory;

        // Update portrait
        portraitImage.sprite = agentSO.portrait;

        // Populate specializations
        PopulateSpecializations();
    }

    public void Initialize(AgentSO agent)
    {
        if (agent == null)
        {
            Debug.LogError("AgentSO passed to Initialize is null.");
            return;
        }

        agentSO = agent;
        UpdateUI();
        Debug.Log($"AgentPanel initialized with Agent: {agent.agentName}");
    }

    private void PopulateSpecializations()
    {
        var usedPlaceholders = new Dictionary<Specialization.SpecializationType, int>
        {
            { Specialization.SpecializationType.ArtCraft, 0 },
            { Specialization.SpecializationType.Fighting, 0 },
            { Specialization.SpecializationType.Firearms, 0 },
            { Specialization.SpecializationType.Science, 0 },
            { Specialization.SpecializationType.Language, 0 },
            { Specialization.SpecializationType.Other, 0 },
            { Specialization.SpecializationType.Survival, 0 }
        };

        foreach (var specialization in agentSO.specializations)
        {
            if (!placeholderNameText.TryGetValue(specialization.type, out var namePlaceholders) ||
                !placeholderValueText.TryGetValue(specialization.type, out var valuePlaceholders))
            {
                //Debug.LogWarning($"No placeholders found for specialization type: {specialization.type}");
                continue;
            }

            int currentIndex = usedPlaceholders[specialization.type];

            if (currentIndex >= namePlaceholders.Count || currentIndex >= valuePlaceholders.Count)
            {
                Debug.LogWarning($"Not enough placeholders for specialization: {specialization.name} of type {specialization.type}");
                continue;
            }

            // Assign specialization
            namePlaceholders[currentIndex].text = specialization.name;
            valuePlaceholders[currentIndex].text = specialization.value.ToString();
            usedPlaceholders[specialization.type]++;
        }
    }


    public void ToggleClicked()
    {
        isClicked = !isClicked;
        Debug.Log($"Agent {agentSO.agentName} clicked state: {isClicked}");
    }

    public void ClearPanel()
    {
        // Reset UI elements (e.g., text, images) to default/empty values
        agentNameText.text = "No Agent";
        portraitImage.sprite = null;
        //statsText.text = string.Empty;

        // Optional: Hide the panel if needed
        gameObject.SetActive(false);
    }
}
