using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AgentPanel : MonoBehaviour
{
    public AgentSO agentSO;
    [Header("Card UI Elements")]
    public TMPro.TextMeshProUGUI cardNameText; // Name displayed on the card
    public Image cardPortraitImage; // Portrait displayed on the card
    
    [Header("Agent File UI Elements")]
    public TMPro.TextMeshProUGUI fileNameText; // Name displayed in the AgentFile
    public Image filePortraitImage; // Portrait displayed in the AgentFile

    [Header("Agent Information")]
    public TextMeshProUGUI agentOccupationText;
    public TextMeshProUGUI agentAgeText;
    public TextMeshProUGUI agentSexText;
    public TextMeshProUGUI agentBackstoryText;

    [Header("Characteristics (Core Stats)")]
    public TextMeshProUGUI strengthText;
    public TextMeshProUGUI constitutionText;
    public TextMeshProUGUI sizeText;
    public TextMeshProUGUI dexterityText;
    public TextMeshProUGUI appearanceText;
    public TextMeshProUGUI educationText;
    public TextMeshProUGUI intelligenceText;
    public TextMeshProUGUI powerText;

    [Header("Abilities (Skills)")]
    public TextMeshProUGUI accountingText;
    public TextMeshProUGUI anthropologyText;
    public TextMeshProUGUI appraiseText;
    public TextMeshProUGUI archaeologyText;
    public TextMeshProUGUI charmText;
    public TextMeshProUGUI climbText;
    public TextMeshProUGUI computerUseText;
    public TextMeshProUGUI creditRatingText;
    public TextMeshProUGUI cthulhuMythosText;
    public TextMeshProUGUI disguiseText;
    public TextMeshProUGUI dodgeText;
    public TextMeshProUGUI driveAutoText;
    public TextMeshProUGUI elecRepairText;
    public TextMeshProUGUI electronicsText;
    public TextMeshProUGUI fastTalkText;
    public TextMeshProUGUI fightingBrawlText;
    public TextMeshProUGUI firstAidText;
    public TextMeshProUGUI historyText;
    public TextMeshProUGUI intimidateText;
    public TextMeshProUGUI jumpText;
    public TextMeshProUGUI lawText;
    public TextMeshProUGUI libraryUseText;
    public TextMeshProUGUI listenText;
    public TextMeshProUGUI locksmithText;
    public TextMeshProUGUI mechRepairText;
    public TextMeshProUGUI medicineText;
    public TextMeshProUGUI naturalWorldText;
    public TextMeshProUGUI navigateText;
    public TextMeshProUGUI occultText;
    public TextMeshProUGUI opHvMachineText;
    public TextMeshProUGUI persuadeText;
    public TextMeshProUGUI pilotText;
    public TextMeshProUGUI psychologyText;
    public TextMeshProUGUI psychanalysisText;
    public TextMeshProUGUI sleightOfHandText;
    public TextMeshProUGUI spotHiddenText;
    public TextMeshProUGUI stealthText;
    public TextMeshProUGUI swimText;
    public TextMeshProUGUI throwText;
    public TextMeshProUGUI trackText;

    [Header("Specialization Placeholders")]
    public TextMeshProUGUI artCraftText;
    public TextMeshProUGUI artCraftValue;
    public TextMeshProUGUI artCraft2Text;
    public TextMeshProUGUI artCraft2Value;
    public TextMeshProUGUI artCraft3Text;
    public TextMeshProUGUI artCraft3Value;
    public TextMeshProUGUI languageOtherText;
    public TextMeshProUGUI languageOtherValue;
    public TextMeshProUGUI language2Text;
    public TextMeshProUGUI language2Value;
    public TextMeshProUGUI languageOwnText;
    public TextMeshProUGUI languageOwnValue;
    public TextMeshProUGUI scienceText;
    public TextMeshProUGUI scienceValue;
    public TextMeshProUGUI science2Text;
    public TextMeshProUGUI science2Value;
    public TextMeshProUGUI science3Text;
    public TextMeshProUGUI science3Value;
    public TextMeshProUGUI fighting2Text;
    public TextMeshProUGUI fighting2Value;
    public TextMeshProUGUI fighting3Text;
    public TextMeshProUGUI fighting3Value;
    public TextMeshProUGUI firearms3Text;
    public TextMeshProUGUI firearms3Value;
    public TextMeshProUGUI survivalText;
    public TextMeshProUGUI survivalValue;
    public TextMeshProUGUI other1Text;
    public TextMeshProUGUI other1Value;
    public TextMeshProUGUI other2Text;
    public TextMeshProUGUI other2Value;
    public TextMeshProUGUI other3Text;
    public TextMeshProUGUI other3Value;
    public TextMeshProUGUI other4Text;
    public TextMeshProUGUI other4Value;
    public TextMeshProUGUI other5Text;
    public TextMeshProUGUI other5Value;


    private bool _isClicked = false;
    public bool isClicked
    {
        get { return _isClicked; }
        private set { _isClicked = value; }
    }

        private void UpdateSpecializations()
    {
        // Check if specializations exist
        if (agentSO.specializations == null || agentSO.specializations.Count < 18)
        {
            GameLogger.LogWarning($"Agent {agentSO.agentName} has an incomplete or missing specializations list. Expected 18.");
            return;
        }

        // Update specialization placeholders
        artCraftValue.text = agentSO.specializations[0].value.ToString();
        artCraft2Value.text = agentSO.specializations[1].value.ToString();
        artCraft3Value.text = agentSO.specializations[2].value.ToString();
        languageOtherValue.text = agentSO.specializations[3].value.ToString();
        language2Value.text = agentSO.specializations[4].value.ToString();
        languageOwnValue.text = agentSO.specializations[5].value.ToString();
        scienceValue.text = agentSO.specializations[6].value.ToString();
        science2Value.text = agentSO.specializations[7].value.ToString();
        science3Value.text = agentSO.specializations[8].value.ToString();
        fighting2Value.text = agentSO.specializations[9].value.ToString();
        fighting3Value.text = agentSO.specializations[10].value.ToString();
        firearms3Value.text = agentSO.specializations[11].value.ToString();
        survivalValue.text = agentSO.specializations[12].value.ToString();
        other1Value.text = agentSO.specializations[13].value.ToString();
        other2Value.text = agentSO.specializations[14].value.ToString();
        other3Value.text = agentSO.specializations[15].value.ToString();
        other4Value.text = agentSO.specializations[16].value.ToString();
        other5Value.text = agentSO.specializations[17].value.ToString();
    }

    private void Start()
    {
        // Initialize specialization names with default values set in the Unity Editor
        artCraftText.text = artCraftText.text;
        artCraft2Text.text = artCraft2Text.text;
        artCraft3Text.text = artCraft3Text.text;
        languageOtherText.text = languageOtherText.text;
        language2Text.text = language2Text.text;
        languageOwnText.text = languageOwnText.text;
        scienceText.text = scienceText.text;
        science2Text.text = science2Text.text;
        science3Text.text = science3Text.text;
        fighting2Text.text = fighting2Text.text;
        fighting3Text.text = fighting3Text.text;
        firearms3Text.text = firearms3Text.text;
        survivalText.text = survivalText.text;
        other1Text.text = other1Text.text;
        other2Text.text = other2Text.text;
        other3Text.text = other3Text.text;
        other4Text.text = other4Text.text;
        other5Text.text = other5Text.text;

        if (agentSO == null)
        {
            GameLogger.LogError("AgentSO is not assigned in AgentPanel.");
        }
        else
        {
            // Initialize UI with existing agent data
            UpdateUI();
        }
    }

    public void Initialize(AgentSO agentData)
    {
        if (agentData == null)
        {
            GameLogger.LogError("Agent data is null. Unable to initialize.");
            return;
        }

        // Assign the AgentSO
        agentSO = agentData;

        // Log initialization start
        GameLogger.Log($"Initializing AgentPanel for Agent: {agentSO.agentName}");

        // Update Card UI Elements
        if (cardNameText != null)
        {
            cardNameText.text = agentSO.agentName;
        }
        else
        {
            GameLogger.LogError("Card name text reference is missing.");
        }

        if (cardPortraitImage != null)
        {
            if (agentSO.profilePhoto != null)
            {
                cardPortraitImage.sprite = agentSO.profilePhoto;
            }
            else
            {
                GameLogger.LogError("AgentSO does not contain a profilePhoto.");
            }
        }
        else
        {
            GameLogger.LogError("Card portrait image reference is missing.");
        }

        // Update Agent File UI Elements
        if (fileNameText != null)
        {
            fileNameText.text = agentSO.agentName;
        }
        else
        {
            GameLogger.LogError("File name text reference is missing.");
        }

        if (filePortraitImage != null)
        {
            if (agentSO.profilePhoto != null)
            {
                filePortraitImage.sprite = agentSO.profilePhoto;
            }
            else
            {
                GameLogger.LogError("AgentSO does not contain a profilePhoto for the file.");
            }
        }
        else
        {
            GameLogger.LogError("File portrait image reference is missing.");
        }

        // Update other UI elements
        UpdateUI();
        UpdateAbilities();
        UpdateSpecializations();

        // Log success
        GameLogger.Log($"AgentPanel successfully initialized for Agent: {agentSO.agentName}");
    }
    



    private void UpdateUI()
    {
        if (agentSO == null)
        {
            GameLogger.LogWarning("No AgentSO assigned to AgentPanel.");
            return;
        }

        // Update Agent Information
        fileNameText.text = agentSO.agentName;
        agentOccupationText.text = $"{agentSO.occupation}";
        agentAgeText.text = $"{agentSO.agentAge}";
        agentSexText.text = $"{agentSO.agentSex}";
        agentBackstoryText.text = $"{agentSO.backstory}";

        // Update Characteristics (Core Stats)
        if (agentSO.currentStats.TryGetValue("Strength", out int strength))
            strengthText.text = strength.ToString();
        else
            strengthText.text = "N/A";

        if (agentSO.currentStats.TryGetValue("Constitution", out int constitution))
            constitutionText.text = constitution.ToString();
        else
            constitutionText.text = "N/A";

        if (agentSO.currentStats.TryGetValue("Size", out int size))
            sizeText.text = size.ToString();
        else
            sizeText.text = "N/A";

        if (agentSO.currentStats.TryGetValue("Dexterity", out int dexterity))
            dexterityText.text = dexterity.ToString();
        else
            dexterityText.text = "N/A";

        if (agentSO.currentStats.TryGetValue("Appearance", out int appearance))
            appearanceText.text = appearance.ToString();
        else
            appearanceText.text = "N/A";

        if (agentSO.currentStats.TryGetValue("Education", out int education))
            educationText.text = education.ToString();
        else
            educationText.text = "N/A";

        if (agentSO.currentStats.TryGetValue("Intelligence", out int intelligence))
            intelligenceText.text = intelligence.ToString();
        else
            intelligenceText.text = "N/A";

        if (agentSO.currentStats.TryGetValue("Power", out int power))
            powerText.text = power.ToString();
        else
            powerText.text = "N/A";
    }


    /// <summary>
    /// Helper method to update the stat text, checks if the key exists in the dictionary.
    /// </summary>
    /// <param name="textComponent">The TextMeshProUGUI component to update.</param>
    /// <param name="statKey">The key to look for in the stats dictionary.</param>
    private void UpdateStatText(TextMeshProUGUI textComponent, string statKey)
    {
        if (agentSO.currentStats != null && agentSO.currentStats.ContainsKey(statKey))
        {
            textComponent.text = agentSO.currentStats[statKey].ToString();
        }
        else
        {
            GameLogger.LogWarning($"Key '{statKey}' not found in currentStats dictionary for Agent: {agentSO?.agentName}");
            textComponent.text = "N/A"; // Set to a default value if the key is not found
        }
    }

    private void UpdateAbilities()
    {
        // Ensure skills are initialized
        if (agentSO.skills == null)
        {
            GameLogger.LogWarning($"Agent {agentSO.agentName} does not have any skills initialized.");
            agentSO.skills = new Dictionary<string, int>(); // Initialize with an empty dictionary to prevent further errors
        }

        accountingText.text = agentSO.skills.ContainsKey("Accounting") ? agentSO.skills["Accounting"].ToString() : "0";
        anthropologyText.text = agentSO.skills.ContainsKey("Anthropology") ? agentSO.skills["Anthropology"].ToString() : "0";
        appraiseText.text = agentSO.skills.ContainsKey("Appraise") ? agentSO.skills["Appraise"].ToString() : "0";
        archaeologyText.text = agentSO.skills.ContainsKey("Archaeology") ? agentSO.skills["Archaeology"].ToString() : "0";
        charmText.text = agentSO.skills.ContainsKey("Charm") ? agentSO.skills["Charm"].ToString() : "0";
        climbText.text = agentSO.skills.ContainsKey("Climb") ? agentSO.skills["Climb"].ToString() : "0";
        computerUseText.text = agentSO.skills.ContainsKey("ComputerUse") ? agentSO.skills["ComputerUse"].ToString() : "0";
        creditRatingText.text = agentSO.skills.ContainsKey("CreditRating") ? agentSO.skills["CreditRating"].ToString() : "0";
        cthulhuMythosText.text = agentSO.skills.ContainsKey("CthulhuMythos") ? agentSO.skills["CthulhuMythos"].ToString() : "0";
        disguiseText.text = agentSO.skills.ContainsKey("Disguise") ? agentSO.skills["Disguise"].ToString() : "0";
        dodgeText.text = agentSO.skills.ContainsKey("Dodge") ? agentSO.skills["Dodge"].ToString() : "0";
        driveAutoText.text = agentSO.skills.ContainsKey("DriveAuto") ? agentSO.skills["DriveAuto"].ToString() : "0";
        elecRepairText.text = agentSO.skills.ContainsKey("ElecRepair") ? agentSO.skills["ElecRepair"].ToString() : "0";
        electronicsText.text = agentSO.skills.ContainsKey("Electronics") ? agentSO.skills["Electronics"].ToString() : "0";
        fastTalkText.text = agentSO.skills.ContainsKey("FastTalk") ? agentSO.skills["FastTalk"].ToString() : "0";
        fightingBrawlText.text = agentSO.skills.ContainsKey("Fighting(Brawl)") ? agentSO.skills["Fighting(Brawl)"].ToString() : "0";
        firstAidText.text = agentSO.skills.ContainsKey("FirstAid") ? agentSO.skills["FirstAid"].ToString() : "0";
        historyText.text = agentSO.skills.ContainsKey("History") ? agentSO.skills["History"].ToString() : "0";
        intimidateText.text = agentSO.skills.ContainsKey("Intimidate") ? agentSO.skills["Intimidate"].ToString() : "0";
        jumpText.text = agentSO.skills.ContainsKey("Jump") ? agentSO.skills["Jump"].ToString() : "0";
        lawText.text = agentSO.skills.ContainsKey("Law") ? agentSO.skills["Law"].ToString() : "0";
        libraryUseText.text = agentSO.skills.ContainsKey("LibraryUse") ? agentSO.skills["LibraryUse"].ToString() : "0";
        listenText.text = agentSO.skills.ContainsKey("Listen") ? agentSO.skills["Listen"].ToString() : "0";
        locksmithText.text = agentSO.skills.ContainsKey("Locksmith") ? agentSO.skills["Locksmith"].ToString() : "0";
        mechRepairText.text = agentSO.skills.ContainsKey("MechRepair") ? agentSO.skills["MechRepair"].ToString() : "0";
        medicineText.text = agentSO.skills.ContainsKey("Medicine") ? agentSO.skills["Medicine"].ToString() : "0";
        naturalWorldText.text = agentSO.skills.ContainsKey("NaturalWorld") ? agentSO.skills["NaturalWorld"].ToString() : "0";
        navigateText.text = agentSO.skills.ContainsKey("Navigate") ? agentSO.skills["Navigate"].ToString() : "0";
        occultText.text = agentSO.skills.ContainsKey("Occult") ? agentSO.skills["Occult"].ToString() : "0";
        opHvMachineText.text = agentSO.skills.ContainsKey("OpHvMachine") ? agentSO.skills["OpHvMachine"].ToString() : "0";
        persuadeText.text = agentSO.skills.ContainsKey("Persuade") ? agentSO.skills["Persuade"].ToString() : "0";
        pilotText.text = agentSO.skills.ContainsKey("Pilot") ? agentSO.skills["Pilot"].ToString() : "0";
        psychologyText.text = agentSO.skills.ContainsKey("Psychology") ? agentSO.skills["Psychology"].ToString() : "0";
        psychanalysisText.text = agentSO.skills.ContainsKey("Psychanalysis") ? agentSO.skills["Psychanalysis"].ToString() : "0";
        sleightOfHandText.text = agentSO.skills.ContainsKey("SleightOfHand") ? agentSO.skills["SleightOfHand"].ToString() : "0";
        spotHiddenText.text = agentSO.skills.ContainsKey("SpotHidden") ? agentSO.skills["SpotHidden"].ToString() : "0";
        stealthText.text = agentSO.skills.ContainsKey("Stealth") ? agentSO.skills["Stealth"].ToString() : "0";
        swimText.text = agentSO.skills.ContainsKey("Swim") ? agentSO.skills["Swim"].ToString() : "0";
        throwText.text = agentSO.skills.ContainsKey("Throw") ? agentSO.skills["Throw"].ToString() : "0";
        trackText.text = agentSO.skills.ContainsKey("Track") ? agentSO.skills["Track"].ToString() : "0";
    }

    public void ToggleClicked()
    {
        isClicked = !isClicked;
        GameLogger.Log($"Agent {agentSO.agentName} clicked state: {isClicked}");
    }

    public void DisplayAgentData()
    {
        if (agentSO == null)
        {
            GameLogger.LogError("AgentSO is not assigned!");
            return;
        }

        GameLogger.Log($"Displaying data for Agent: {agentSO.agentName}");
    }

    public void SetAgentData(AgentSO newAgentSO)
    {
        if (newAgentSO == null)
        {
            GameLogger.LogError("New AgentSO is null!");
            return;
        }

        agentSO = newAgentSO;
        UpdateUI();
    }

    public void ClearPanel()
    {
        // Reset UI elements to default/empty values
        if (fileNameText != null)
            fileNameText.text = "No Agent";
        if (agentOccupationText != null)
            agentOccupationText.text = "";
        if (agentAgeText != null)
            agentAgeText.text = "";
        if (agentSexText != null)
            agentSexText.text = "";
        if (agentBackstoryText != null)
            agentBackstoryText.text = "";

        // Clear Characteristics (Core Stats)
        strengthText.text = "";
        constitutionText.text = "";
        sizeText.text = "";
        dexterityText.text = "";
        appearanceText.text = "";
        educationText.text = "";
        intelligenceText.text = "";
        powerText.text = "";

        // Clear Abilities (Skills)
        accountingText.text = "";
        anthropologyText.text = "";
        appraiseText.text = "";
        archaeologyText.text = "";
        charmText.text = "";
        climbText.text = "";
        computerUseText.text = "";
        creditRatingText.text = "";
        cthulhuMythosText.text = "";
        disguiseText.text = "";
        dodgeText.text = "";
        driveAutoText.text = "";
        elecRepairText.text = "";
        electronicsText.text = "";
        fastTalkText.text = "";
        fightingBrawlText.text = "";
        firstAidText.text = "";
        historyText.text = "";
        intimidateText.text = "";
        jumpText.text = "";
        lawText.text = "";
        libraryUseText.text = "";
        listenText.text = "";
        locksmithText.text = "";
        mechRepairText.text = "";
        medicineText.text = "";
        naturalWorldText.text = "";
        navigateText.text = "";
        occultText.text = "";
        opHvMachineText.text = "";
        persuadeText.text = "";
        pilotText.text = "";
        psychologyText.text = "";
        psychanalysisText.text = "";
        sleightOfHandText.text = "";
        spotHiddenText.text = "";
        stealthText.text = "";
        swimText.text = "";
        throwText.text = "";
        trackText.text = "";

        // Clear Specializations
        artCraftText.text = "";
        artCraft2Text.text = "";
        artCraft3Text.text = "";
        languageOtherText.text = "";
        language2Text.text = "";
        languageOwnText.text = "";
        scienceText.text = "";
        science2Text.text = "";
        science3Text.text = "";
        fighting2Text.text = "";
        fighting3Text.text = "";
        firearms3Text.text = "";
        survivalText.text = "";
        other1Text.text = "";
        other2Text.text = "";
        other3Text.text = "";
        other4Text.text = "";
        other5Text.text = "";
    }
}
