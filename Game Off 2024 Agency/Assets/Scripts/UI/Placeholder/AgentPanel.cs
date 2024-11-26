using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AgentPanel : MonoBehaviour
{
    public AgentSO agentSO;

    [Header("Agent Information")]
    public TextMeshProUGUI agentNameText;
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
    public TextMeshProUGUI artCraft2Text;
    public TextMeshProUGUI artCraft3Text;
    public TextMeshProUGUI languageOtherText;
    public TextMeshProUGUI language2Text;
    public TextMeshProUGUI languageOwnText;
    public TextMeshProUGUI scienceText;
    public TextMeshProUGUI science2Text;
    public TextMeshProUGUI science3Text;
    public TextMeshProUGUI fighting2Text;
    public TextMeshProUGUI fighting3Text;
    public TextMeshProUGUI firearms3Text;
    public TextMeshProUGUI survivalText;
    public TextMeshProUGUI other1Text;
    public TextMeshProUGUI other2Text;
    public TextMeshProUGUI other3Text;
    public TextMeshProUGUI other4Text;
    public TextMeshProUGUI other5Text;

    private bool _isClicked = false;
    public bool isClicked
    {
        get { return _isClicked; }
        private set { _isClicked = value; }
    }

    public void Initialize(AgentSO agentData)
    {
        if (agentData == null)
        {
            Debug.LogError("Agent data is null. Unable to initialize.");
            return;
        }

        agentSO = agentData;
        UpdateUI();
        UpdateAbilities();
        UpdateSpecializations();
    }

    private void UpdateUI()
    {
        if (agentSO == null)
        {
            Debug.LogWarning("No AgentSO assigned to AgentPanel.");
            return;
        }

        // Update Agent Information
        agentNameText.text = agentSO.agentName;
        agentOccupationText.text = $"Occupation: {agentSO.occupation}";
        agentAgeText.text = $"Age: {agentSO.agentAge}";
        agentSexText.text = $"Sex: {agentSO.agentSex}";
        agentBackstoryText.text = $"Backstory:\n{agentSO.backstory}";

        // Update Characteristics (Core Stats)
        strengthText.text = agentSO.currentStats["Strength"].ToString();
        constitutionText.text = agentSO.currentStats["Constitution"].ToString();
        sizeText.text = agentSO.currentStats["Size"].ToString();
        dexterityText.text = agentSO.currentStats["Dexterity"].ToString();
        appearanceText.text = agentSO.currentStats["Appearance"].ToString();
        educationText.text = agentSO.currentStats["Education"].ToString();
        intelligenceText.text = agentSO.currentStats["Intelligence"].ToString();
        powerText.text = agentSO.currentStats["Power"].ToString();
    }

    /// <summary>
    /// Helper method to update the stat text, checks if the key exists in the dictionary.
    /// </summary>
    /// <param name="textComponent">The TextMeshProUGUI component to update.</param>
    /// <param name="statKey">The key to look for in the stats dictionary.</param>
    private void UpdateStatText(TextMeshProUGUI textComponent, string statKey)
    {
        if (agentSO.currentStats.ContainsKey(statKey))
        {
            textComponent.text = agentSO.currentStats[statKey].ToString();
        }
        else
        {
            Debug.LogWarning($"Key '{statKey}' not found in currentStats dictionary.");
            textComponent.text = "N/A"; // Set to a default value if the key is not found
        }
    }

    private void UpdateAbilities()
    {
        // Update abilities (skills)
        accountingText.text = $"{agentSO.skills["Accounting"]}%";
        anthropologyText.text = $"{agentSO.skills["Anthropology"]}%";
        appraiseText.text = $"{agentSO.skills["Appraise"]}%";
        archaeologyText.text = $"{agentSO.skills["Archaeology"]}%";
        charmText.text = $"{agentSO.skills["Charm"]}%";
        climbText.text = $"{agentSO.skills["Climb"]}%";
        computerUseText.text = $"{agentSO.skills["ComputerUse"]}%";
        creditRatingText.text = $"{agentSO.skills["CreditRating"]}%";
        cthulhuMythosText.text = $"{agentSO.skills["CthulhuMythos"]}%";
        disguiseText.text = $"{agentSO.skills["Disguise"]}%";
        dodgeText.text = $"{agentSO.skills["Dodge"]}%";
        driveAutoText.text = $"{agentSO.skills["DriveAuto"]}%";
        elecRepairText.text = $"{agentSO.skills["ElecRepair"]}%";
        electronicsText.text = $"{agentSO.skills["Electronics"]}%";
        fastTalkText.text = $"{agentSO.skills["FastTalk"]}%";
        fightingBrawlText.text = $"{agentSO.skills["Fighting(Brawl)"]}%";
        firstAidText.text = $"{agentSO.skills["FirstAid"]}%";
        historyText.text = $"{agentSO.skills["History"]}%";
        intimidateText.text = $"{agentSO.skills["Intimidate"]}%";
        jumpText.text = $"{agentSO.skills["Jump"]}%";
        lawText.text = $"{agentSO.skills["Law"]}%";
        libraryUseText.text = $"{agentSO.skills["LibraryUse"]}%";
        listenText.text = $"{agentSO.skills["Listen"]}%";
        locksmithText.text = $"{agentSO.skills["Locksmith"]}%";
        mechRepairText.text = $"{agentSO.skills["MechRepair"]}%";
        medicineText.text = $"{agentSO.skills["Medicine"]}%";
        naturalWorldText.text = $"{agentSO.skills["NaturalWorld"]}%";
        navigateText.text = $"{agentSO.skills["Navigate"]}%";
        occultText.text = $"{agentSO.skills["Occult"]}%";
        opHvMachineText.text = $"{agentSO.skills["OpHvMachine"]}%";
        persuadeText.text = $"{agentSO.skills["Persuade"]}%";
        pilotText.text = $"{agentSO.skills["Pilot"]}%";
        psychologyText.text = $"{agentSO.skills["Psychology"]}%";
        psychanalysisText.text = $"{agentSO.skills["Psychanalysis"]}%";
        sleightOfHandText.text = $"{agentSO.skills["SleightOfHand"]}%";
        spotHiddenText.text = $"{agentSO.skills["SpotHidden"]}%";
        stealthText.text = $"{agentSO.skills["Stealth"]}%";
        swimText.text = $"{agentSO.skills["Swim"]}%";
        throwText.text = $"{agentSO.skills["Throw"]}%";
        trackText.text = $"{agentSO.skills["Track"]}%";
    }

    private void UpdateSpecializations()
    {
        // Update specialization placeholders
        artCraftText.text = $"{agentSO.specializations[0].value}%";
        artCraft2Text.text = $"{agentSO.specializations[1].value}%";
        artCraft3Text.text = $"{agentSO.specializations[2].value}%";
        languageOtherText.text = $"{agentSO.specializations[3].value}%";
        language2Text.text = $"{agentSO.specializations[4].value}%";
        languageOwnText.text = $"{agentSO.specializations[5].value}%";
        scienceText.text = $"{agentSO.specializations[6].value}%";
        science2Text.text = $"{agentSO.specializations[7].value}%";
        science3Text.text = $"{agentSO.specializations[8].value}%";
        fighting2Text.text = $"{agentSO.specializations[9].value}%";
        fighting3Text.text = $"{agentSO.specializations[10].value}%";
        firearms3Text.text = $"{agentSO.specializations[11].value}%";
        survivalText.text = $"{agentSO.specializations[12].value}%";
        other1Text.text = $"{agentSO.specializations[13].value}%";
        other2Text.text = $"{agentSO.specializations[14].value}%";
        other3Text.text = $"{agentSO.specializations[15].value}%";
        other4Text.text = $"{agentSO.specializations[16].value}%";
        other5Text.text = $"{agentSO.specializations[17].value}%";
    }

    public void ToggleClicked()
    {
        isClicked = !isClicked;
        Debug.Log($"Agent {agentSO.agentName} clicked state: {isClicked}");
    }

    private void Start()
    {
        if (agentSO == null)
        {
            Debug.LogError("AgentSO is not assigned in AgentPanel");
        }
        // Initialize or clear the UI
        ClearPanel();
    }

    public void DisplayAgentData()
    {
        if (agentSO == null)
        {
            Debug.LogError("AgentSO is not assigned!");
            return;
        }

        Debug.Log($"Displaying data for Agent: {agentSO.agentName}");
    }

    public void SetAgentData(AgentSO newAgentSO)
    {
        if (newAgentSO == null)
        {
            Debug.LogError("New AgentSO is null!");
            return;
        }

        agentSO = newAgentSO;
        UpdateUI();
    }

    public void ClearPanel()
    {
        // Reset UI elements to default/empty values
        if (agentNameText != null)
            agentNameText.text = "No Agent";
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
