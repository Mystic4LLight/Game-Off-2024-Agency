using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AgentPanel : MonoBehaviour
{
    // Corris: shoud be Agent, not AgentSO 
    [SerializeField] public Agent agent;

    [SerializeField] public AgentSO agentSO;
    [SerializeField] private TextMeshProUGUI agentName;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private Image profilePhoto;
    [Header("Stats")]
    [SerializeField] private TextMeshProUGUI strength;
    [SerializeField] private TextMeshProUGUI constitution;
    [SerializeField] private TextMeshProUGUI size;
    [SerializeField] private TextMeshProUGUI dexterity;
    [SerializeField] private TextMeshProUGUI appearance;
    [SerializeField] private TextMeshProUGUI education;
    [SerializeField] private TextMeshProUGUI intelligence;
    [SerializeField] private TextMeshProUGUI power;
    [Header("Abilities")]
    [SerializeField] private TextMeshProUGUI accounting;
    [SerializeField] private TextMeshProUGUI anthropology;
    [SerializeField] private TextMeshProUGUI appraise;
    [SerializeField] private TextMeshProUGUI archaeology;
    [SerializeField] private TextMeshProUGUI artCraft1;
    [SerializeField] private TextMeshProUGUI artCraft2;
    [SerializeField] private TextMeshProUGUI artCraft3;
    [SerializeField] private TextMeshProUGUI charm;
    [SerializeField] private TextMeshProUGUI climb;
    [SerializeField] private TextMeshProUGUI computerUse;
    [SerializeField] private TextMeshProUGUI creditRating;
    [SerializeField] private TextMeshProUGUI cthulhuMythos;
    [SerializeField] private TextMeshProUGUI disguise;
    [SerializeField] private TextMeshProUGUI dodge;
    [SerializeField] private TextMeshProUGUI driveAuto;
    [SerializeField] private TextMeshProUGUI elecRepair;
    [SerializeField] private TextMeshProUGUI electronics;
    [SerializeField] private TextMeshProUGUI fastTalk;
    [SerializeField] private TextMeshProUGUI fightingBrawl;
    [SerializeField] private TextMeshProUGUI fighting2;
    [SerializeField] private TextMeshProUGUI fighting3;
    [SerializeField] private TextMeshProUGUI firearmsAiming;
    [SerializeField] private TextMeshProUGUI firearmsHipshot;
    [SerializeField] private TextMeshProUGUI firearms3;
    [SerializeField] private TextMeshProUGUI firstAid;
    [SerializeField] private TextMeshProUGUI history;
    [SerializeField] private TextMeshProUGUI intimidate;
    [SerializeField] private TextMeshProUGUI jump;
    [SerializeField] private TextMeshProUGUI languageOther1;
    [SerializeField] private TextMeshProUGUI languageOther2;
    [SerializeField] private TextMeshProUGUI languageOwn;
    [SerializeField] private TextMeshProUGUI law;
    [SerializeField] private TextMeshProUGUI libraryUse;
    [SerializeField] private TextMeshProUGUI listen;
    [SerializeField] private TextMeshProUGUI locksmith;
    [SerializeField] private TextMeshProUGUI mechRepair;
    [SerializeField] private TextMeshProUGUI medicine;
    [SerializeField] private TextMeshProUGUI naturalWorld;
    [SerializeField] private TextMeshProUGUI navigate;
    [SerializeField] private TextMeshProUGUI occult;
    [SerializeField] private TextMeshProUGUI opHvMachine;
    [SerializeField] private TextMeshProUGUI persuade;
    [SerializeField] private TextMeshProUGUI pilot;
    [SerializeField] private TextMeshProUGUI psychology;
    [SerializeField] private TextMeshProUGUI psychanalysis;
    [SerializeField] private TextMeshProUGUI science1;
    [SerializeField] private TextMeshProUGUI science2;
    [SerializeField] private TextMeshProUGUI science3;
    [SerializeField] private TextMeshProUGUI sleightOfHand;
    [SerializeField] private TextMeshProUGUI spotHidden;
    [SerializeField] private TextMeshProUGUI stealth;
    [SerializeField] private TextMeshProUGUI survival1;
    [SerializeField] private TextMeshProUGUI swim;
    [SerializeField] private TextMeshProUGUI throw1;
    [SerializeField] private TextMeshProUGUI track;
    [SerializeField] private TextMeshProUGUI other1;
    [SerializeField] private TextMeshProUGUI other2;
    [SerializeField] private TextMeshProUGUI other3;
    [SerializeField] private TextMeshProUGUI other4;
    [SerializeField] private TextMeshProUGUI other5;
    public bool isClicked = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (agent != null)
            Update_Stat();
    }

    void Update_Stat()
    {

    }

    public void clickButton(){
        isClicked = true;
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
                Debug.LogWarning($"No placeholders found for specialization type: {specialization.type}");
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
}
