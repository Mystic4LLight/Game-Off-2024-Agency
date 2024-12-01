using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AgentStatsManager
{
    public static void InitializeAgentStatsAndSkills(AgentSO agent)
    {
        // Roll all the stats first and store them in a list
        List<int> rolledStats = new List<int>
        {
            RollDice(2, 6, 5) + 30,  // 2D6+6 * 5 for stats (first)
            RollDice(2, 6, 5) + 30,  // 2D6+6 * 5 (second)
            RollDice(2, 6, 5) + 30,  // 2D6+6 * 5 (third)
            RollDice(3, 6, 5),       // 3D6 * 5 for stats (fourth)
            RollDice(3, 6, 5),       // 3D6 * 5 (fifth)
            RollDice(3, 6, 5),       // 3D6 * 5 (sixth)
            RollDice(3, 6, 5),       // 3D6 * 5 (seventh)
            RollDice(3, 6, 5)        // 3D6 * 5 (eighth)
        };

        // Sort the rolls in descending order to assign them better to the archetype strengths
        rolledStats.Sort((a, b) => b.CompareTo(a));

        agent.currentStats = new Dictionary<string, int>();

        // Assign stats based on archetype
        switch (agent.archetype)
        {
            case "Adventurer":
                agent.currentStats["Strength"] = rolledStats[0];       // Highest stat for Strength
                agent.currentStats["Dexterity"] = rolledStats[1];      // Second highest for Dexterity
                agent.currentStats["Constitution"] = rolledStats[2];
                agent.currentStats["Power"] = rolledStats[3];
                agent.currentStats["Size"] = rolledStats[4];
                agent.currentStats["Intelligence"] = rolledStats[5];
                agent.currentStats["Education"] = rolledStats[6] + 20; // Education always gets an extra boost
                agent.currentStats["Appearance"] = rolledStats[7];
                break;

            case "Egghead":
                agent.currentStats["Intelligence"] = rolledStats[0];   // Highest stat for Intelligence
                agent.currentStats["Education"] = rolledStats[1] + 20; // Second highest for Education, with extra boost
                agent.currentStats["Power"] = rolledStats[2];
                agent.currentStats["Dexterity"] = rolledStats[3];
                agent.currentStats["Size"] = rolledStats[4];
                agent.currentStats["Constitution"] = rolledStats[5];
                agent.currentStats["Appearance"] = rolledStats[6];
                agent.currentStats["Strength"] = rolledStats[7];       // Lowest for Strength
                break;

            case "Grease Monkey":
                agent.currentStats["Dexterity"] = rolledStats[0];      // Highest for Dexterity
                agent.currentStats["Intelligence"] = rolledStats[1];
                agent.currentStats["Constitution"] = rolledStats[2];
                agent.currentStats["Education"] = rolledStats[3] + 20; // Education boost
                agent.currentStats["Power"] = rolledStats[4];
                agent.currentStats["Size"] = rolledStats[5];
                agent.currentStats["Strength"] = rolledStats[6];
                agent.currentStats["Appearance"] = rolledStats[7];
                break;

            case "Gumshoe":
                agent.currentStats["Intelligence"] = rolledStats[0];   // Highest for Intelligence
                agent.currentStats["Dexterity"] = rolledStats[1];
                agent.currentStats["Power"] = rolledStats[2];
                agent.currentStats["Constitution"] = rolledStats[3];
                agent.currentStats["Education"] = rolledStats[4] + 20; // Education boost
                agent.currentStats["Appearance"] = rolledStats[5];
                agent.currentStats["Size"] = rolledStats[6];
                agent.currentStats["Strength"] = rolledStats[7];       // Lowest for Strength
                break;

            case "Heavy":
                agent.currentStats["Strength"] = rolledStats[0];       // Highest for Strength
                agent.currentStats["Constitution"] = rolledStats[1];   // Second highest for Constitution
                agent.currentStats["Size"] = rolledStats[2];           // Larger body size
                agent.currentStats["Power"] = rolledStats[3];
                agent.currentStats["Dexterity"] = rolledStats[4];
                agent.currentStats["Education"] = rolledStats[5] + 20; // Education boost
                agent.currentStats["Intelligence"] = rolledStats[6];
                agent.currentStats["Appearance"] = rolledStats[7];
                break;

            case "Mystic":
                agent.currentStats["Power"] = rolledStats[0];          // Highest for Power (paranormal connection)
                agent.currentStats["Intelligence"] = rolledStats[1];
                agent.currentStats["Education"] = rolledStats[2] + 20; // Education boost
                agent.currentStats["Appearance"] = rolledStats[3];
                agent.currentStats["Dexterity"] = rolledStats[4];
                agent.currentStats["Constitution"] = rolledStats[5];
                agent.currentStats["Size"] = rolledStats[6];
                agent.currentStats["Strength"] = rolledStats[7];       // Lowest for Strength
                break;

            case "Swashbuckler":
                agent.currentStats["Dexterity"] = rolledStats[0];      // Highest for Dexterity
                agent.currentStats["Strength"] = rolledStats[1];
                agent.currentStats["Appearance"] = rolledStats[2];     // Charismatic appearance
                agent.currentStats["Constitution"] = rolledStats[3];
                agent.currentStats["Power"] = rolledStats[4];
                agent.currentStats["Size"] = rolledStats[5];
                agent.currentStats["Intelligence"] = rolledStats[6];
                agent.currentStats["Education"] = rolledStats[7] + 20; // Education boost
                break;

            case "Thrill-Seeker":
                agent.currentStats["Dexterity"] = rolledStats[0];      // Highest for Dexterity
                agent.currentStats["Strength"] = rolledStats[1];
                agent.currentStats["Constitution"] = rolledStats[2];
                agent.currentStats["Power"] = rolledStats[3];
                agent.currentStats["Size"] = rolledStats[4];
                agent.currentStats["Appearance"] = rolledStats[5];
                agent.currentStats["Intelligence"] = rolledStats[6];
                agent.currentStats["Education"] = rolledStats[7] + 20; // Education boost
                break;

            case "Weird Scientist":
                agent.currentStats["Intelligence"] = rolledStats[0];   // Highest for Intelligence
                agent.currentStats["Education"] = rolledStats[1] + 20; // Education boost
                agent.currentStats["Dexterity"] = rolledStats[2];
                agent.currentStats["Power"] = rolledStats[3];
                agent.currentStats["Appearance"] = rolledStats[4];
                agent.currentStats["Size"] = rolledStats[5];
                agent.currentStats["Constitution"] = rolledStats[6];
                agent.currentStats["Strength"] = rolledStats[7];       // Lowest for Strength
                break;

            case "Marksman":
                agent.currentStats["Dexterity"] = rolledStats[0];      // Highest for Dexterity
                agent.currentStats["Power"] = rolledStats[1];
                agent.currentStats["Intelligence"] = rolledStats[2];
                agent.currentStats["Size"] = rolledStats[3];
                agent.currentStats["Education"] = rolledStats[4] + 20; // Education boost
                agent.currentStats["Strength"] = rolledStats[5];
                agent.currentStats["Constitution"] = rolledStats[6];
                agent.currentStats["Appearance"] = rolledStats[7];
                break;

            default:
                
    if (string.IsNullOrEmpty(agent.archetype))
    {
        GameLogger.LogWarning("Archetype is missing or empty. Defaulting to 'Everyman/Woman'.");
        agent.archetype = "Everyman/Woman";
    }
    else
    {
        GameLogger.LogWarning("Unknown archetype, assigning default rolls for stats.");
    }
    
                agent.currentStats["Strength"] = rolledStats[0];
                agent.currentStats["Constitution"] = rolledStats[1];
                agent.currentStats["Size"] = rolledStats[2];
                agent.currentStats["Dexterity"] = rolledStats[3];
                agent.currentStats["Appearance"] = rolledStats[4];
                agent.currentStats["Education"] = rolledStats[5] + 20; // Education boost
                agent.currentStats["Intelligence"] = rolledStats[6];
                agent.currentStats["Power"] = rolledStats[7];
                break;
        }

        // Ensure all keys exist in the dictionary before accessing them
        foreach (var key in new List<string> { "Strength", "Constitution", "Size", "Dexterity", "Appearance", "Education", "Intelligence", "Power" })
        {
            if (!agent.currentStats.ContainsKey(key))
            {
                agent.currentStats[key] = 0;
            }
        }


        // Initialize skills with their default base values
        agent.skills = new Dictionary<string, int>
        {
            { "Accounting", 5 },
            { "Anthropology", 1 },
            { "Appraise", 5 },
            { "Archaeology", 1 },
            { "Charm", 15 },
            { "Climb", 20 },
            { "ComputerUse", 5 },
            { "CreditRating", 0 },
            { "CthulhuMythos", 0 },
            { "Disguise", 5 },
            { "Dodge", agent.currentStats["Dexterity"] / 2 }, // Dodge starts at DEX/2
            { "DriveAuto", 20 },
            { "ElecRepair", 10 },
            { "Electronics", 1 },
            { "FastTalk", 5 }, // Corrected the default value for Fast Talk
            { "Fighting(Brawl)", 25 },
            { "FirstAid", 30 },
            { "Firearms(Aiming)", 20 }, // Initialize Firearms(Aiming) with a base value
            { "Firearms(Hipshot)", 25 }, // Initialize Firearms(Hipshot) with a base value
            { "History", 5 },
            { "Intimidate", 15 },
            { "Jump", 20 },
            { "Law", 5 },
            { "LibraryUse", 20 },
            { "Listen", 25 },
            { "Locksmith", 1 },
            { "MechRepair", 10 },
            { "Medicine", 1 },
            { "NaturalWorld", 10 },
            { "Navigate", 10 },
            { "Occult", 5 },
            { "OpHvMachine", 1 },
            { "Persuade", 10 },
            { "Pilot", 1 },
            { "Psychology", 10 },
            { "Psychoanalysis", 1 },
            { "SleightOfHand", 10 },
            { "SpotHidden", 25 },
            { "Stealth", 20 },
            { "Swim", 20 },
            { "Throw", 20 },
            { "Track", 10 }
        };

        // Add archetype-specific skills or bonuses
        switch (agent.archetype)
        {
            case "Adventurer":
                EnsureSkillInitialized(agent, "Climb");
                EnsureSkillInitialized(agent, "Navigate");
                EnsureSkillInitialized(agent, "Survival");

                agent.skills["Climb"] += 40;
                agent.skills["Navigate"] += 30;
                agent.skills["Survival"] += 50;
                break;

            case "Egghead":
                EnsureSkillInitialized(agent, "ComputerUse");
                EnsureSkillInitialized(agent, "LibraryUse");
                EnsureSkillInitialized(agent, "Science");

                agent.skills["ComputerUse"] += 50;
                agent.skills["LibraryUse"] += 40;
                agent.skills["Science"] += 30;
                break;

            case "Grease Monkey":
                EnsureSkillInitialized(agent, "MechRepair");
                EnsureSkillInitialized(agent, "Electronics");
                EnsureSkillInitialized(agent, "ElecRepair");

                agent.skills["MechRepair"] += 50;
                agent.skills["Electronics"] += 40;
                agent.skills["ElecRepair"] += 30;
                break;

            case "Gumshoe":
                EnsureSkillInitialized(agent, "SpotHidden");
                EnsureSkillInitialized(agent, "Psychology");
                EnsureSkillInitialized(agent, "LibraryUse");

                agent.skills["SpotHidden"] += 50;
                agent.skills["Psychology"] += 40;
                agent.skills["LibraryUse"] += 30;
                break;

            case "Heavy":
                EnsureSkillInitialized(agent, "Fighting(Brawl)");
                EnsureSkillInitialized(agent, "Intimidate");
                EnsureSkillInitialized(agent, "Strength");

                agent.skills["Fighting(Brawl)"] += 60;
                agent.skills["Intimidate"] += 40;
                agent.currentStats["Strength"] += 20; // Adjust the stat directly
                break;

            case "Mystic":
                EnsureSkillInitialized(agent, "Occult");
                EnsureSkillInitialized(agent, "History");
                EnsureSkillInitialized(agent, "Persuade");

                agent.skills["Occult"] += 50;
                agent.skills["History"] += 40;
                agent.skills["Persuade"] += 30;
                break;

            case "Swashbuckler":
                EnsureSkillInitialized(agent, "Fighting(Brawl)");
                EnsureSkillInitialized(agent, "Dodge");
                EnsureSkillInitialized(agent, "Charm");

                agent.skills["Fighting(Brawl)"] += 50;
                agent.skills["Dodge"] += 40;
                agent.skills["Charm"] += 30;
                break;

            case "Thrill-Seeker":
                EnsureSkillInitialized(agent, "Jump");
                EnsureSkillInitialized(agent, "DriveAuto");
                EnsureSkillInitialized(agent, "Stealth");

                agent.skills["Jump"] += 50;
                agent.skills["DriveAuto"] += 40;
                agent.skills["Stealth"] += 30;
                break;

            case "Weird Scientist":
                EnsureSkillInitialized(agent, "Science");
                EnsureSkillInitialized(agent, "Occult");
                EnsureSkillInitialized(agent, "Electronics");

                agent.skills["Science"] += 50;
                agent.skills["Occult"] += 40;
                agent.skills["Electronics"] += 30;
                break;

            case "Marksman":
                EnsureSkillInitialized(agent, "Firearms(Aiming)");
                EnsureSkillInitialized(agent, "SpotHidden");
                EnsureSkillInitialized(agent, "Dodge");

                agent.skills["Firearms(Aiming)"] += 60;
                agent.skills["SpotHidden"] += 40;
                agent.skills["Dodge"] += 20;
                break;

            case "Everyman/Woman":
                EnsureSkillInitialized(agent, "Persuade");
                EnsureSkillInitialized(agent, "SpotHidden");
                EnsureSkillInitialized(agent, "FastTalk");

                agent.skills["Persuade"] += 30;
                agent.skills["SpotHidden"] += 20;
                agent.skills["FastTalk"] += 20;
                break;

            default:
                GameLogger.LogWarning("Unknown archetype, assigning default skills.");
                EnsureSkillInitialized(agent, "Accounting");
                EnsureSkillInitialized(agent, "LibraryUse");

                agent.skills["Accounting"] += 10;
                agent.skills["LibraryUse"] += 20;
                break;
        }
    }

    public static void EnsureSkillInitialized(AgentSO agent, string skillName)
    {
        if (agent == null)
        {
            GameLogger.LogError("Cannot ensure skill initialization. AgentSO is null.");
            return;
        }

        if (agent.skills == null)
        {
            GameLogger.LogWarning($"Skills dictionary for {agent.agentName} is null. Initializing a new dictionary.");
            agent.skills = new Dictionary<string, int>();
        }

        if (!agent.skills.ContainsKey(skillName))
        {
            agent.skills[skillName] = 0; // Default value for uninitialized skills
            GameLogger.Log($"Initialized skill '{skillName}' for agent {agent.agentName} with default value 0.");
        }
    }

    public static int RollDice(int numberOfDice, int sides, int multiplier = 1)
    {
        int total = 0;

        for (int i = 0; i < numberOfDice; i++)
        {
            total += Random.Range(1, sides + 1);
        }

        int result = total * multiplier;
        return result;
    }
}
