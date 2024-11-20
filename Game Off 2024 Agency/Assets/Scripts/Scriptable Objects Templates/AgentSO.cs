using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "AgentSO", menuName = "Scriptable Objects/AgentSO")]
public class AgentSO : ScriptableObject
{
    public new string name;
    public string description;

    public AgentSkill requiredSkillForAnalysis; // The skill required for this artifact's analysis

    public Sprite profilePhoto;
    [Header("Stats")]
    public int strength;
    public int constitution;
    public int size;
    public int dexterity;
    public int appearance;
    public int education;
    public int intelligence;
    public int power;
    [Header("Abilities")]
    public int accounting;
    public int anthropology;
    public int appraise;
    public int archaeology;
    public int artCraft1;
    public int artCraft2;
    public int artCraft3;
    public int charm;
    public int climb;
    public int computerUse;
    public int creditRating;
    public int cthulhuMythos;
    public int disguise;
    public int dodge;
    public int driveAuto;
    public int elecRepair;
    public int electronics;
    public int fastTalk;
    public int fightingBrawl;
    public int fighting2;
    public int fighting3;
    public int firearmsAiming;
    public int firearmsHipshot;
    public int firearms3;
    public int firstAid;
    public int history;
    public int intimidate;
    public int jump;
    public int languageOther1;
    public int languageOther2;
    public int languageOwn;
    public int law;
    public int libraryUse;
    public int listen;
    public int locksmith;
    public int mechRepair;
    public int medicine;
    public int naturalWorld;
    public int navigate;
    public int occult;
    public int opHvMachine;
    public int persuade;
    public int pilot;
    public int psychology;
    public int psychanalysis;
    public int science1;
    public int science2;
    public int science3;
    public int sleightOfHand;
    public int spotHidden;
    public int stealth;
    public int survival1;
    public int swim;
    public int throw1;
    public int track;
    public int other1;
    public int other2;
    public int other3;
    public int other4;
    public int other5;

    [SerializeField] private AgentSkill primarySkill;
    public Dictionary<AgentSkill, int> skills = new Dictionary<AgentSkill, int>();




    // Initialize or set a skill level
    public void SetSkillLevel(AgentSkill skill, int level)
    {
        skills[skill] = level;
    }

    // Get the skill level for a given skill type
    public int GetSkillLevel(AgentSkill skill)
    {
        return skills.ContainsKey(skill) ? skills[skill] : 0;
    }

}
