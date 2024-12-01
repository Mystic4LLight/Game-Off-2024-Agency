using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class AgentPanel : MonoBehaviour
{
    public AgentSO agentSO; // The ScriptableObject holding the agent's data
    public bool isInitialized = false; // Tracks whether the panel has been initialized
    public bool isClicked = false;

    [Header("Agent Card UI")]
    public TextMeshProUGUI agentCardName; // Name on the card
    public Image agentCardPhoto; // Photo on the card

    [Header("Basic Information")]
    public TextMeshProUGUI agentName;
    public TextMeshProUGUI agentOccupation;
    public TextMeshProUGUI agentAge;
    public TextMeshProUGUI agentSex;
    public TextMeshProUGUI agentHobbies; // To display hobbies
    public TextMeshProUGUI agentBackstory;
    public Image profilePhoto;

    [Header("Base Stats")]
    public TextMeshProUGUI strengthText;
    public TextMeshProUGUI constitutionText;
    public TextMeshProUGUI sizeText;
    public TextMeshProUGUI dexterityText;
    public TextMeshProUGUI appearanceText;
    public TextMeshProUGUI educationText;
    public TextMeshProUGUI intelligenceText;
    public TextMeshProUGUI powerText;

    [Header("Abilities")]
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
    public TextMeshProUGUI firearmsAimingText;
    public TextMeshProUGUI firearmsHipshotText;
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
    public TextMeshProUGUI psychoanalysisText;
    public TextMeshProUGUI sleightOfHandText;
    public TextMeshProUGUI spotHiddenText;
    public TextMeshProUGUI stealthText;
    public TextMeshProUGUI swimText;
    public TextMeshProUGUI throwText;
    public TextMeshProUGUI trackText;

    [Header("Specialization Placeholders")]
    public TextMeshProUGUI artCraftText, artCraftValue; // Art/Craft specialization
    public TextMeshProUGUI artCraft2Text, artCraft2Value; // Art/Craft (secondary) specialization
    public TextMeshProUGUI artCraft3Text, artCraft3Value; // Art/Craft (tertiary) specialization
    public TextMeshProUGUI languageOtherText, languageOtherValue; // Language (Other)
    public TextMeshProUGUI language2Text, language2Value; // Language (secondary)
    public TextMeshProUGUI languageOwnText, languageOwnValue; // Language (Own)
    public TextMeshProUGUI scienceText, scienceValue; // Science specialization
    public TextMeshProUGUI science2Text, science2Value; // Science (secondary)
    public TextMeshProUGUI science3Text, science3Value; // Science (tertiary)
    public TextMeshProUGUI fighting2Text, fighting2Value; // Fighting (secondary)
    public TextMeshProUGUI fighting3Text, fighting3Value; // Fighting (tertiary)
    public TextMeshProUGUI firearms3Text, firearms3Value; // Firearms (tertiary)
    public TextMeshProUGUI survivalText, survivalValue; // Survival specialization
    public TextMeshProUGUI other1Text, other1Value; // Other specialization 1
    public TextMeshProUGUI other2Text, other2Value; // Other specialization 2
    public TextMeshProUGUI other3Text, other3Value; // Other specialization 3
    public TextMeshProUGUI other4Text, other4Value; // Other specialization 4
    public TextMeshProUGUI other5Text, other5Value; // Other specialization 5


    // Dictionary to map skill names to the corresponding UI elements
    private Dictionary<string, TextMeshProUGUI> agentAbilities;

    private void Awake()
    {
        GameLogger.Log("AgentPanel: Awake called.");

        // Initialize abilities dictionary
        InitializeAbilitiesDictionary();

        // Ensure abilities are cleared
        ClearAbilities();
    }

    private void Start()
    {
        // Lazy initialization to ensure AgentSO is assigned before proceeding
        if (agentSO != null)
        {
            UpdatePanel(agentSO);
        }
        else
        {
            GameLogger.LogWarning("AgentSO is null. Initialization deferred until AgentSO is assigned.");
        }
    }

    // Method to provide the AgentSO reference
    public AgentSO GetAgentSO()
    {
        return agentSO;
    }

    private void InitializeAbilitiesDictionary()
    {
        agentAbilities = new Dictionary<string, TextMeshProUGUI>
        {
            { "Accounting", accountingText },
            { "Anthropology", anthropologyText },
            { "Appraise", appraiseText },
            { "Archaeology", archaeologyText },
            { "Charm", charmText },
            { "Climb", climbText },
            { "ComputerUse", computerUseText },
            { "CreditRating", creditRatingText },
            { "CthulhuMythos", cthulhuMythosText },
            { "Disguise", disguiseText },
            { "Dodge", dodgeText },
            { "DriveAuto", driveAutoText },
            { "ElecRepair", elecRepairText },
            { "Electronics", electronicsText },
            { "FastTalk", fastTalkText },
            { "Fighting(Brawl)", fightingBrawlText },
            { "Firearms(Aiming)", firearmsAimingText },
            { "Firearms(Hipshot)", firearmsHipshotText },
            { "FirstAid", firstAidText },
            { "History", historyText },
            { "Intimidate", intimidateText },
            { "Jump", jumpText },
            { "Law", lawText },
            { "LibraryUse", libraryUseText },
            { "Listen", listenText },
            { "Locksmith", locksmithText },
            { "MechRepair", mechRepairText },
            { "Medicine", medicineText },
            { "NaturalWorld", naturalWorldText },
            { "Navigate", navigateText },
            { "Occult", occultText },
            { "OpHvMachine", opHvMachineText },
            { "Persuade", persuadeText },
            { "Pilot", pilotText },
            { "Psychology", psychologyText },
            { "Psychoanalysis", psychoanalysisText },
            { "SleightOfHand", sleightOfHandText },
            { "SpotHidden", spotHiddenText },
            { "Stealth", stealthText },
            { "Swim", swimText },
            { "Throw", throwText },
            { "Track", trackText }
        };
    }

    // Method to clear all abilities text
    private void ClearAbilities()
    {
        foreach (var ability in agentAbilities.Values)
        {
            ability.text = "";
        }
        GameLogger.Log("AgentPanel: Abilities cleared.");
    }

    // Method to update all stats and skills
    public void UpdatePanel(AgentSO agent)
    {
        if (agent == null)
        {
            GameLogger.LogWarning("UpdatePanel called with a null AgentSO.");
            return;
        }

        // Update agent details in the UI
        agentName.text = agent.agentName;
        agentOccupation.text = agent.occupation;
        agentAge.text = agent.agentAge.ToString();
        agentSex.text = agent.agentSex;
        agentBackstory.text = agent.backstory;

        // Update basic stats
        strengthText.text = agent.currentStats["Strength"].ToString();
        constitutionText.text = agent.currentStats["Constitution"].ToString();
        sizeText.text = agent.currentStats["Size"].ToString();
        dexterityText.text = agent.currentStats["Dexterity"].ToString();
        appearanceText.text = agent.currentStats["Appearance"].ToString();
        educationText.text = agent.currentStats["Education"].ToString();
        intelligenceText.text = agent.currentStats["Intelligence"].ToString();
        powerText.text = agent.currentStats["Power"].ToString();

        // Update skills
        accountingText.text = agent.skills["Accounting"].ToString();
        anthropologyText.text = agent.skills["Anthropology"].ToString();
        appraiseText.text = agent.skills["Appraise"].ToString();
        archaeologyText.text = agent.skills["Archaeology"].ToString();
        charmText.text = agent.skills["Charm"].ToString();
        climbText.text = agent.skills["Climb"].ToString();
        computerUseText.text = agent.skills["ComputerUse"].ToString();
        creditRatingText.text = agent.skills["CreditRating"].ToString();
        cthulhuMythosText.text = agent.skills["CthulhuMythos"].ToString();
        disguiseText.text = agent.skills["Disguise"].ToString();
        dodgeText.text = agent.skills["Dodge"].ToString();
        driveAutoText.text = agent.skills["DriveAuto"].ToString();
        elecRepairText.text = agent.skills["ElecRepair"].ToString();
        electronicsText.text = agent.skills["Electronics"].ToString();
        fastTalkText.text = agent.skills["FastTalk"].ToString();
        fightingBrawlText.text = agent.skills["Fighting(Brawl)"].ToString();
        firearmsAimingText.text = agent.skills["Firearms(Aiming)"].ToString();
        firearmsHipshotText.text = agent.skills["Firearms(Hipshot)"].ToString();
        firstAidText.text = agent.skills["FirstAid"].ToString();
        historyText.text = agent.skills["History"].ToString();
        intimidateText.text = agent.skills["Intimidate"].ToString();
        jumpText.text = agent.skills["Jump"].ToString();
        lawText.text = agent.skills["Law"].ToString();
        libraryUseText.text = agent.skills["LibraryUse"].ToString();
        listenText.text = agent.skills["Listen"].ToString();
        locksmithText.text = agent.skills["Locksmith"].ToString();
        mechRepairText.text = agent.skills["MechRepair"].ToString();
        medicineText.text = agent.skills["Medicine"].ToString();
        naturalWorldText.text = agent.skills["NaturalWorld"].ToString();
        navigateText.text = agent.skills["Navigate"].ToString();
        occultText.text = agent.skills["Occult"].ToString();
        opHvMachineText.text = agent.skills["OpHvMachine"].ToString();
        persuadeText.text = agent.skills["Persuade"].ToString();
        pilotText.text = agent.skills["Pilot"].ToString();
        psychologyText.text = agent.skills["Psychology"].ToString();
        psychoanalysisText.text = agent.skills["Psychoanalysis"].ToString();
        sleightOfHandText.text = agent.skills["SleightOfHand"].ToString();
        spotHiddenText.text = agent.skills["SpotHidden"].ToString();
        stealthText.text = agent.skills["Stealth"].ToString();
        swimText.text = agent.skills["Swim"].ToString();
        throwText.text = agent.skills["Throw"].ToString();
        trackText.text = agent.skills["Track"].ToString();

        // Update specialization placeholders
        artCraftText.text = "Art/Craft\n----";
        artCraftValue.text = "0";

        artCraft2Text.text = "----";
        artCraft2Value.text = "0";

        artCraft3Text.text = "----";
        artCraft3Value.text = "0";

        languageOtherText.text = "Language(Other)\n----";
        languageOtherValue.text = "0";

        language2Text.text = "----";
        language2Value.text = "0";

        languageOwnText.text = "Language(Own)\n----";
        languageOwnValue.text = "0";

        scienceText.text = "Science\n----";
        scienceValue.text = "0";

        science2Text.text = "----";
        science2Value.text = "0";

        science3Text.text = "----";
        science3Value.text = "0";

        fighting2Text.text = "----";
        fighting2Value.text = "0";

        fighting3Text.text = "----";
        fighting3Value.text = "0";

        firearms3Text.text = "----";
        firearms3Value.text = "0";

        survivalText.text = "Survival\n----";
        survivalValue.text = "0";

        other1Text.text = "----";
        other1Value.text = "0";

        other2Text.text = "----";
        other2Value.text = "0";

        other3Text.text = "----";
        other3Value.text = "0";

        other4Text.text = "----";
        other4Value.text = "0";

        other5Text.text = "----";
        other5Value.text = "0";
    
        // Update Hobbies
        if (agent.hobbies != null && agent.hobbies.Count > 0)
        {
            agentHobbies.text = string.Join(", ", agent.hobbies);
        }
        else
        {
            agentHobbies.text = "None";
        }

        // Update AgentCard UI
        agentCardName.text = agent.agentName;

        if (agentCardPhoto != null && agent.profilePhoto != null)
        {
            agentCardPhoto.sprite = agent.profilePhoto;
        }
        else
        {
            GameLogger.LogWarning("AgentCard photo is null.");
        }

        // Profile Picture for Agent File UI
        if (profilePhoto != null && agent.profilePhoto != null)
        {
            profilePhoto.sprite = agent.profilePhoto;
        }
        else
        {
            GameLogger.LogWarning("Profile photo is null.");
        }

        // Basic Stats (ensure the naming matches AgentSO)
        strengthText.text = agent.currentStats["Strength"].ToString();
        constitutionText.text = agent.currentStats["Constitution"].ToString();
        sizeText.text = agent.currentStats["Size"].ToString();
        dexterityText.text = agent.currentStats["Dexterity"].ToString();
        appearanceText.text = agent.currentStats["Appearance"].ToString();
        educationText.text = agent.currentStats["Education"].ToString();
        intelligenceText.text = agent.currentStats["Intelligence"].ToString();
        powerText.text = agent.currentStats["Power"].ToString();
    }

}
