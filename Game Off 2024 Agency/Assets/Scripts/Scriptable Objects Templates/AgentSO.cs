using System.Collections.Generic;
using System.Linq;
using UnityEngine;
#if UNITY_EDITOR   // to react on change in Unity Editor - AgentStarTemplateSO field of AgentSO
using UnityEditor;
#endif

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

    // (Corris:) 
    [Header("Stats")]
    public AgentStatTemplateSO statTemplate; // Link to shadblon with list of Stat parameters
    // All stats - edit in Unity Editor
    public List<AgentStat> stats = new();

    // 'Constructor' to add default properties to list
    private void OnEnable()
    {
#if UNITY_EDITOR
        if (statTemplate == null) // if template didn't set - try to find it in Unity
        {
            FindStatTemplate("AgentStatTemplateSO");
        }
#endif
        if (statTemplate != null)
            SyncStatsWithTemplate();
    }

    // Update stats list if template was changed (need this as reaction to Template changed in Unity Editor
    private void OnValidate()
    {
        if (statTemplate != null)
        {
            SyncStatsWithTemplate();
        }
    }


    private void SyncStatsWithTemplate()
    {
        // if list is empty, add all stats from template
        if (stats.Count == 0)
        {
            InitializeStats();
            return;
        }

        // check if all stats from template are in list
        foreach (var templateStat in statTemplate.stats)
        {
            if (!stats.Any(s => s.template == templateStat))
            {
                stats.Add(new AgentStat(templateStat)); // add new stat
            }
        }

        // remove stats that are not in template  (maybe they from old ersion of template)
        stats.RemoveAll(s => !statTemplate.stats.Contains(s.template));
    }

    private void InitializeStats()
    {
        stats = statTemplate.stats
            .Select(template => new AgentStat(template))
            .ToList();
    }

#if UNITY_EDITOR
    private void FindStatTemplate(string _AgentStatTemplateName)
    {
        // Looking for existing in Unity Editor  template AgentStatTemplateSO
      //  string[] guids = AssetDatabase.FindAssets("t:AgentStatTemplateSO");
        string[] guids = AssetDatabase.FindAssets("t:"+ _AgentStatTemplateName);
        if (guids.Length > 0)
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[0]);
            statTemplate = AssetDatabase.LoadAssetAtPath<AgentStatTemplateSO>(path);
        }
        else
        {
       /*     // If not found - creating new one
            statTemplate = ScriptableObject.CreateInstance<AgentStatTemplateSO>();
            string assetPath = "Assets/AgentStatTemplateSO.asset";
            AssetDatabase.CreateAsset(statTemplate, assetPath);
            AssetDatabase.SaveAssets();
            Debug.Log("Created new AgentStatTemplateSO at " + assetPath);   
       */
        }

        EditorUtility.SetDirty(this); // Mark object as dirty to save changes
    }
#endif


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
